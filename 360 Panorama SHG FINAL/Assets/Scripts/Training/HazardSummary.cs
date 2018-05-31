using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HazardSummary : MonoBehaviour {

	public Text summaryText;
	public string content;

	// Use this for initialization
	void Start () {
		this.transform.LookAt(Camera.main.transform);
		summaryText = this.GetComponentInChildren<Text>();
		this.summaryText.text = content;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt(Camera.main.transform);
	}

	public void populateText(string text) {
		summaryText.text = text;
	}
}
