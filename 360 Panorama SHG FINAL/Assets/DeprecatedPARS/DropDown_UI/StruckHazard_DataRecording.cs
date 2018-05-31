using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class StruckHazard_DataRecording : MonoBehaviour {

	List<string> options = new List<string>() { "Please Select an Option","Safety Glasses & Shield", "Vehicle Safety", "Elevated Materials"};

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

//		string appendText = "{" +"\"Scene\": " + "\""+scene.name+"\"" + ", " + "\"Type of Hazard\": \"Struck\"" + ", " + "\"Hazard Selection\": " + "\"" + selectedOption+"\"" + ", "+ "\"Time Stamp\": " + "\""+ System.DateTime.Now.ToString()+ "\"" + "}" +"\r\n";
//		System.IO.File.AppendAllText("C:/Users/DarkB/Downloads/VH Prototype/DataOutput/Hazards.json", appendText);

		string ss = SystemInfo.deviceUniqueIdentifier;
		string appendText = scene.name + ", " + "Struck_By" + ", " + selectedOption + ", " + System.DateTime.Now.ToString() + "\r\n";
		System.IO.File.AppendAllText(Path.GetTempPath() + "\\PanoExperiment_"+ ss + "\\Hazards.txt", appendText);
//		System.IO.File.AppendAllText("C:/Users/DarkB/Downloads/VH Prototype/DataOutput/Hazards.txt", appendText);
	}	
}