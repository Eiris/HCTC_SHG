using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingController : PARSController {

	public List<TrainingHazard> currentRoundTrainingHazards;
	public List<TrainingHazardController> currentRoundTrainingHazardControllers;
	public new TrainingDataManager dataManager;

	void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	// Use this for initialization
	void Start () {
		this.isTimedTraining = Settings.s.T_forcedTimeNavigationEnabled;
		this.isAllowedToSelfNavigate = Settings.s.T_selfNavigationEnabled;
		this.allowedTimePerRound = Settings.s.T_roundForcedTimeLimit;
		this.totalRoundCount = Settings.s.T_roundsTotalCount;
		this.currentRoundIndex = 1;
		this.type = 'T';
		this.startTime = System.DateTime.Now;
		this.dataManager = new TrainingDataManager ("trainingResponses.json", this);
		this.startRound();
	}

	public void setOtherStatesToOff(TrainingHazardController selectedHazardController){
		foreach(TrainingHazardController hazardController in currentRoundTrainingHazardControllers) {
			if(hazardController != selectedHazardController) {
				hazardController.SetState("HazardOffState");
			}
		}
	}

	public override void startRound(){
		this.currentRound = new Round(this.getCurrentSceneID());
	}

	public void beginRound() {
		try {
			GameObject[] trainingHazards = GameObject.FindGameObjectsWithTag("hazard");
			TrainingCollectionController collection = GameObject.FindGameObjectWithTag("collection").GetComponent<TrainingCollectionController>();
			collection.removeAllCells();
			foreach(GameObject hazardObject in trainingHazards) {
				TrainingHazardController hazardController = hazardObject.GetComponent<TrainingHazardController>();
				currentRoundTrainingHazardControllers.Add(hazardController);
				hazardController.setDelegate(this);
				hazardController.cell = collection.addCell(hazardController);
			}
		} catch (NullReferenceException ex) {
			Debug.Log("Could not find training hazards and collection at beginning of the round");
		}
	}

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
		this.beginRound();
    }

	public override void completeCurrentRound(){
		GameObject[] trainingHazards = GameObject.FindGameObjectsWithTag("hazard");
		List<TrainingHazard> sceneHazards = new List<TrainingHazard>();
		foreach(GameObject hazardObject in trainingHazards) {
			TrainingHazardController hc = hazardObject.GetComponent<TrainingHazardController>();
			sceneHazards.Add(hc.hazard);
		}
		currentRound.setResponses(sceneHazards);
		currentRoundTrainingHazardControllers.Clear();
		base.completeCurrentRound();
	}

	public override void complete() {
		base.complete();
		try {
			dataManager.save();
		} catch (NullReferenceException exp) {
			Debug.Log("Could not save data");
		}
		SceneManager.LoadScene("04_A_Start");
		Destroy(this.gameObject);
	}
}
