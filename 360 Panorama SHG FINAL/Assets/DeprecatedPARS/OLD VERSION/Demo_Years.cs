using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Demo_Years : MonoBehaviour {

	public InputField yearsfield;
	private string years;

//	void Awake(){
//		yearsfield = gameObject.Find ("InputField").GetComponent<InputField> ();
//	}

	public void OnSubmit(){
		years = yearsfield.text;
		WriteFile ();
		yearsfield.text = "";
	}

	void WriteFile(){

		//		string appendText = "{" +"\"Scene\": " + "\""+scene.name+"\"" + ", " + "\"Type of Hazard\": \"Caught\"" + ", " + "\"Hazard Selection\": " + "\"" + selectedOption+"\"" + ", "+ "\"Time Stamp\": " + "\""+ System.DateTime.Now.ToString()+ "\"" + "}" +"\r\n";
		//		System.IO.File.AppendAllText("C:/Users/DarkB/Downloads/VH Prototype/DataOutput/Hazards.json", appendText);

		string ss = SystemInfo.deviceUniqueIdentifier;
		string appendText = "Experience Years" + " - " + years + ", " + System.DateTime.Now.ToString() + "\r\n";
		System.IO.File.AppendAllText(Path.GetTempPath() + "\\PanoExperiment_" + ss + "\\Demographics.txt", appendText);
//		System.IO.File.AppendAllText("C:/Users/DarkB/Downloads/VH Prototype/DataOutput/Demographics.txt", appendText);

	}
}
