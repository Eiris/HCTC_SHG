using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour {

	public PARSController controller;

	public Text timerText;

	// Use this for initialization
	void Start () {
		this.fetchController();
	}

	// Update is called once per frame
	void Update () {
		if(this.controller == null) {
			this.fetchController();
		}
	}

	private void fetchController() {
		GameObject controllerGO = GameObject.FindGameObjectWithTag("controller");
		if(controllerGO.GetComponent<PARSController>().currentRoundIndex != null) {
			this.controller = controllerGO.GetComponent<PARSController>();
			this.controller.set(this);
			this.setupUI();
		}
	}

	private void setupUI() {
		Text[] texts = this.GetComponentsInChildren<Text>();
		foreach (Text text in texts) {
			switch (text.name) {
				case "typeText" :
					switch (this.controller.getControllerType()) {
						case 'T':
							text.text = "training session";
							break;
						case 'A':
							text.text = "assessment session";
							break;
						default: 
							break;
					}
					break;
				case "counterText" :
					text.text = controller.finishedRounds.Count+1 + "/" + controller.totalRoundCount;
					break;
				case "timerText" : 
					timerText = text;
					timerText.text = "";
					break;
			}
		}

	}

	public void setTimerText(string time) {
		timerText.text = time;
	}

	public void setTimerColor(Color color) {
		timerText.color = color;
	}

	public void pressedNext() {
		this.controller.completeCurrentRound();
	}
}
