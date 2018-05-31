using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AssessmentController : PARSController
{	 
	public AnswerKey answerKey;

	// Use this for initialization
	void Start ()
	{
		this.isTimedTraining = Settings.s.A_forcedTimeNavigationEnabled;
		this.isAllowedToSelfNavigate = Settings.s.A_selfNavigationEnabled;
		this.allowedTimePerRound = Settings.s.A_roundForcedTimeLimit;
		this.totalRoundCount = Settings.s.A_roundsTotalCount;
		this.type = 'A';
		this.dataManager = new PARSDataManager ("assessmentResponses.json");
		this.startTime = System.DateTime.Now;
		this.currentRoundIndex = 1;
		this.startRound();
		print(Application.persistentDataPath);
		dataManager.retrieveAnswers(populateAnswerKey);
	}

	public override void startRound(){
		this.currentRound = new AssessmentRound (getCurrentSceneID());
	}

	public override void completeCurrentRound(){
		List<Hazard> activeToggles = this.getActiveToggleHazards();
		currentRound.setResponses(activeToggles);
		print(answerKey.gradeForRound(currentRound));
		base.completeCurrentRound();
	}

	public override void complete(){
		base.complete();
		this.gradeAssessment();
		this.dataManager.saveAssessmentTime(this.startTime, this.endTime);
		this.dataManager.saveRounds(this.finishedRounds);
		this.dataManager.saveToFile();
		SceneManager.LoadScene ("12_Results");
	}

	List<Hazard> getActiveToggleHazards() {
		List<Hazard> activeToggles = new List<Hazard>();
		GameObject[] toggles = GameObject.FindGameObjectsWithTag("Radio");
		foreach(GameObject go in toggles) {
			Toggle toggle = go.GetComponent<Toggle>();
			if(toggle.isOn) {
				ToggleController tc = go.GetComponent<ToggleController>();
				activeToggles.Add(new Hazard(tc.category, tc.value));
			}
		}
		return activeToggles;
	}

	public void populateAnswerKey(Question[] questions){
		answerKey = new AnswerKey(questions);
	}

	void gradeAssessment(){
		foreach(AssessmentRound round in this.finishedRounds) {
			round.HIIScore = answerKey.gradeForRound(round);
		}
	}
}