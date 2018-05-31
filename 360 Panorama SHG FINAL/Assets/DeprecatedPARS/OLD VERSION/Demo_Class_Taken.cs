using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Demo_Class_Taken : MonoBehaviour {

	List<string> options = new List<string>() { "Please Select an Option", "BCN3255", "BCN4252", "Other"};

	public Dropdown dropdown; 
	private string selectedOption;

	public void Dropdown_IndexChanged(int index)
	{
		selectedOption = options[index];
		WriteFile ();
	}

	void Start () 
	{
		PopulateList ();	
	}

	void PopulateList()
	{
		dropdown.AddOptions (options);
	}

	void WriteFile(){

		//		string appendText = "{" +"\"Scene\": " + "\""+scene.name+"\"" + ", " + "\"Type of Hazard\": \"Caught\"" + ", " + "\"Hazard Selection\": " + "\"" + selectedOption+"\"" + ", "+ "\"Time Stamp\": " + "\""+ System.DateTime.Now.ToString()+ "\"" + "}" +"\r\n";
		//		System.IO.File.AppendAllText("C:/Users/DarkB/Downloads/VH Prototype/DataOutput/Hazards.json", appendText);

		string appendText = "Class of Survey" + " - " + selectedOption + ", " + System.DateTime.Now.ToString() + "\r\n";
		string ss = SystemInfo.deviceUniqueIdentifier;
		System.IO.File.AppendAllText(Path.GetTempPath() + "\\PanoExperiment_" + ss + "\\Demographics.txt", appendText);
//		System.IO.File.AppendAllText("C:/Users/DarkB/Downloads/VH Prototype/DataOutput/Demographics.txt", appendText);

	}
}
