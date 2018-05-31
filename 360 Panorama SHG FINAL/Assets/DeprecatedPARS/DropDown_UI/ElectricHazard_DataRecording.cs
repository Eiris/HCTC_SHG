using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ElectricHazard_DataRecording : MonoBehaviour {

	List<string> options = new List<string>() { "Please Select an Option", "Equipment Tag-Out", "Temporary Lighting", "Extension Cords & Outlets"};

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

//		string appendText = "{" +"\"Scene\": " + "\""+scene.name+"\"" + ", " + "\"Type of Hazard\": \"Electric\"" + ", " + "\"Hazard Selection\": " + "\"" + selectedOption+"\"" + ", "+ "\"Time Stamp\": " + "\""+ System.DateTime.Now.ToString()+ "\"" + "}" +"\r\n";
//		System.IO.File.AppendAllText("C:/Users/DarkB/Downloads/VH Prototype/DataOutput/Hazards.json", appendText);

		string ss = SystemInfo.deviceUniqueIdentifier;
		string appendText = scene.name + ", " + "Electrical" + ", " + selectedOption + ", " + System.DateTime.Now.ToString() + "\r\n";
		System.IO.File.AppendAllText(Path.GetTempPath() + "\\PanoExperiment_" + ss + "\\Hazards.txt", appendText);
//		System.IO.File.AppendAllText("C:/Users/DarkB/Downloads/VH Prototype/DataOutput/Hazards.txt", appendText);
	}	
}