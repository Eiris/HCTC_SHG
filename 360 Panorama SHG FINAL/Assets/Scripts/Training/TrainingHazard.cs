using UnityEngine;
using System.IO;
using System;

[Serializable]
public class TrainingHazard : Hazard {
	public string summaryText;
	public Color color;
	public float duration;
	
	public TrainingHazard(string category, string name) : base(category, name) {
		this.duration = 0;
		this.color = Color.cyan;
	}
	
	public void incrementDuration() {
		this.duration += Time.deltaTime;
	}
}