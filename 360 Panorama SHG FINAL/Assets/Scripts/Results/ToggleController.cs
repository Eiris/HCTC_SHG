using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour {

	public string category;
	public string value;


	void Start() {
		Text toggleLabel = GetComponentInChildren<Text>();
		toggleLabel.text = value;
	}
}
