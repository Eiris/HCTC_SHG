using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class DemographicViewController : MonoBehaviour {

	public InputField studyTextField;
	public ToggleGroup demographicToggles;

	// Use this for initialization
	void Start () {
		this.studyTextField = this.GetComponentInChildren<InputField>();
		this.demographicToggles = this.GetComponentInChildren<ToggleGroup>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void buttonPressed() {
		Toggle activeToggle = this.demographicToggles.ActiveToggles().First();
		if(activeToggle == null) {
			// NOT GOOD!
			// TODO: Make the text red and warn the person
		} else {
			string demographic = activeToggle.GetComponentInChildren<Text>().text;
			PlayerPrefs.SetString("demographic", demographic);
		}

		string studyID = this.studyTextField.text;
		if(studyID == null) {
			// NOT GOOOO either
		} else {
			PlayerPrefs.SetString("studyID", studyID);
		}

		PlayerPrefs.Save();
		SceneManager.LoadScene("03_T_Start");
	}
}
