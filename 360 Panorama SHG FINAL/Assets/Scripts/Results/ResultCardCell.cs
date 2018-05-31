using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultCardCell : MonoBehaviour {

	public Text sceneLabel;
	public ResultAnswersList correctList;
	public ResultAnswersList yourList;
	public Text hiiScoreLabel;
	public Text notesLabel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void populateAssessmentResults(AssessmentRound roundResult, AnswerKey answers) {
		string sceneID = roundResult.getSceneID();
		sceneLabel.text = "assessment scene " + sceneID;
		correctList.populateList(answers.dictionary[sceneID]);
		yourList.populateCorrectList(roundResult.getResponseHazardNames().ToArray(), answers.dictionary[sceneID]);
		hiiScoreLabel.text = "your HII Score: " + roundResult.HIIScore + "%";
		notesLabel.text = "";//"notes can go here";
		Canvas.ForceUpdateCanvases();
		GetComponent<VerticalLayoutGroup>().enabled = false;
		GetComponent<VerticalLayoutGroup>().enabled = true;
	}
}
