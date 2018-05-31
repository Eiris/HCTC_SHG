using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TrainingHazardController : MonoBehaviour {

	public TrainingHazard hazard;

	public HazardIconController icon;
	public HazardContentView content;
	public TrainingCollectionCell cell;
	
	private TrainingController tcDelegate;
	private State currentState;

	// Use this for initialization
	void Start () {
		if(this.hazard == null) {
			this.hazard = new TrainingHazard("laddes", "hey there");
		}
		this.icon = this.GetComponentInChildren<HazardIconController>();
		this.icon.setColor(this.hazard.color);
		this.content = this.GetComponentInChildren<HazardContentView>();
		SetState(new HazardOffState(this));
	}
	
	// Update is called once per frame
	void Update () {
		if(currentState is HazardOnState) {
			this.hazard.incrementDuration();
		}
	}

	public void setDelegate(TrainingController tc) {
		this.tcDelegate = tc;
	}

	public void setColor(Color color) {
		print("COLOR GOT CALLED!");
	}

	public void setVisibility(bool enabled) {
		this.content.setContentVisibilty(enabled);
	}
	
	public void SetState(State state)
    {
		Debug.Log("Set the state: " + state);
        if (currentState != null)
            currentState.OnStateExit();

        currentState = state;

        if (currentState != null)
            currentState.OnStateEnter();
    }

	public void SetState(string stateName) {
		switch (stateName)
		{
			case "HazardOnState":
				this.SetState(new HazardOnState(this));
				break;
			case "HazardOffState":
				this.SetState(new HazardOffState(this));
				break;
		}
	}
	
	public State ToggleState() {
		this.tcDelegate.setOtherStatesToOff(this);
		Debug.Log("We called the toggle switch: " + this.tcDelegate);
		State newState = null;
		if (currentState is HazardOffState) {
			newState = new HazardOnState(this);
		} else if (currentState is HazardOnState) {
			newState = new HazardOffState(this);
		}
		SetState(newState);
		return newState;
	}

	public void SetStateOff() {
		if (currentState is HazardOnState) {
			this.ToggleState();
		}
	}
}
