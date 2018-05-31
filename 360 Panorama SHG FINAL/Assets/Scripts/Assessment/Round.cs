using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[Serializable]
public class Round {
	private string sceneID;
	public string startTime;
	public string endTime;
	public List<Hazard> hazardResponses;
	public List<TrainingHazard> trainingHazardData;

	public Round(string sceneID){
		this.sceneID = sceneID;
		this.startTime = System.DateTime.Now.ToString("yyyy-MM-dd\\THH:mm:ss\\Z");
	}

	public string getSceneID() {
		return sceneID;
	}

	public void completeRound() {
		this.endTime = System.DateTime.Now.ToString("yyyy-MM-dd\\THH:mm:ss\\Z");
	}

	public virtual void setResponses(List<TrainingHazard> responses) {
		this.trainingHazardData = responses;
	}

	public virtual void setResponses(List<Hazard> responses) {
		this.hazardResponses = responses;
	}

	public List<String> getResponseHazardNames() {
		List<string> roundResultHazardNames = new List<string>();
		foreach (Hazard hazard in hazardResponses) {
			roundResultHazardNames.Add(hazard.name);
		}
		return roundResultHazardNames;
	}
}