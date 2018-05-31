using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsController : MonoBehaviour {

	public ResultCardCell ResultCardCell;
	public AssessmentController controller;
	public Text overallScoreLabel;

	// Use this for initialization
	void Start () {
		controller = FindObjectOfType(typeof(AssessmentController)) as AssessmentController;
		float overallScore = 0.0f;
		foreach (AssessmentRound result in controller.finishedRounds) {
			var newCell = Instantiate(ResultCardCell, transform);
			newCell.transform.parent = transform;
			newCell.populateAssessmentResults(result, controller.answerKey);
			overallScore += result.HIIScore;
		}
		this.populateOverallScore(overallScore / (float)controller.finishedRounds.Count);
	}

	void populateOverallScore(float overallScore) {
		overallScoreLabel.text = "YOUR OVERALL SCORE: " + overallScore.ToString() + "%";
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}

	public void endSession() {
		DestroyImmediate(controller.gameObject, true);
	}
}
