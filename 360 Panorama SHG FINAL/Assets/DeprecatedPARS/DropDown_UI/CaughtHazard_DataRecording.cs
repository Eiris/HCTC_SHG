using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CaughtHazard_DataRecording : MonoBehaviour {

	List<string> options = new List<string>() { "Please Select an Option", "Equipment Swing", "Material Storage", "Excavation and Pipes"};

	public Dropdown dropdown; 
	private string selectedOption;
	private Scene scene;

	public void Dropdown_IndexChanged(int index)
	{
		selectedOption = options[index];
		WriteFile ();
	}

	void Start () 
	{
		PopulateList ();	
		scene = SceneManager.GetActiveScene ();
	}

	void PopulateList()
	{
		dropdown.AddOptions (options);
	}

	void WriteFile(){

		string ss = SystemInfo.deviceUniqueIdentifier;
		string appendText = scene.name + ", " + "Caught-In" + ", " + selectedOption + ", " + System.DateTime.Now.ToString() + "\r\n";
		System.IO.File.AppendAllText(Path.GetTempPath() + "\\PanoExperiment_" + ss + "\\Hazards.txt", appendText);

	}	
}