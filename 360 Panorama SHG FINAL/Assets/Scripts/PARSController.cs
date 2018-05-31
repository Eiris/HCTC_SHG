using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PARSController : MonoBehaviour {
	public static PARSController instance;

	public int allowedTimePerRound;
	public bool isTimedTraining;
	public bool isAllowedToSelfNavigate;
	public int totalRoundCount;
	public int? currentRoundIndex;
	public Round currentRound;

	public List<Round> finishedRounds;
	 
	public PARSDataManager dataManager;
	public NavigationController navigationController;

	public System.DateTime startTime;
	public System.DateTime endTime;

	public char type;

	void Awake()
	{
		// If the instance reference has not been set, yet,
		if (instance == null)
		{
			// Set this instance as the instance reference.
			instance = this;
		}
		else if(instance != this)
		{
			// If the instance reference has already been set, and this is not the
			// the instance reference, destroy this game object.
			Destroy(gameObject);
		}

		// Do not destroy this object, when we load a new scene.
		DontDestroyOnLoad(gameObject);
	}

	void Update() {
		if(this.isTimedTraining) {
			this.set(this.allowedTimePerRound - (int)(System.DateTime.Now.Subtract(System.DateTime.ParseExact(this.currentRound.startTime, "yyyy-MM-dd\\THH:mm:ss\\Z", CultureInfo.InvariantCulture)).TotalSeconds));
		}
	}

	public virtual void set(NavigationController navigationController) {
		this.navigationController = navigationController;
		GameObject navigationButton = this.navigationController.GetComponentInChildren<Button>().gameObject;
		navigationButton.SetActive(this.isAllowedToSelfNavigate);
	}

	protected virtual void set(int secondsLeft) {
		if(this.navigationController != null) {
			if(secondsLeft < 0) {
				this.completeCurrentRound();
			} else {
				string timeElapsed = this.formatTime(secondsLeft);
				this.navigationController.setTimerText(timeElapsed);
				if(secondsLeft < Settings.s.dangerZoneTime) {
					this.navigationController.setTimerColor(new Color(1.0f, 0.26f, 0.26f));
				}
			}
		}
	}

	protected string formatTime(int totalSeconds) {
		int minutes = totalSeconds / 60;
		int seconds = totalSeconds % 60;
		return string.Format ("{0:00}:{1:00}", minutes, seconds);
	}

	protected string getCurrentSceneID(){
		return "0" + this.currentRoundIndex + "_" + this.type;
	}

	public char getControllerType() {
		return this.type;
	}

	public virtual void startRound(){
		this.currentRound = new Round (getCurrentSceneID());
	}

	public virtual void completeCurrentRound() {
		print("COMPLETED THE ROUND for SCENE " + currentRound.getSceneID());
		currentRound.completeRound();
		finishedRounds.Add(currentRound);
		this.changeToNextRound();
	}

	protected virtual void changeToNextRound() {
		this.currentRoundIndex += 1;
		print("Changing to scene " + this.currentRound.getSceneID());
		if(this.currentRoundIndex <= this.totalRoundCount) {
			this.startRound();
			SceneManager.LoadScene (this.currentRound.getSceneID());
		} else {
			this.complete();
			//go to next scene outside of evaluation
		}
	}

	public virtual void complete(){
		print("Assessment to be Finished");
		this.endTime = System.DateTime.Now;
	}
}
