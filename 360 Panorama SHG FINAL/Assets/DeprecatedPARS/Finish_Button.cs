using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class Finish_Button : MonoBehaviour {

	public GameObject ks;
	public float time = 2;

	void Start (){
		ks.gameObject.SetActive(false);

	}

	IEnumerator timer (){
		ks.gameObject.SetActive(true);
		yield return new WaitForSeconds (time);
		ks.gameObject.SetActive(false);
	}


	public void TaskOnClick (string sceneToChangeTo){
		string ss = SystemInfo.deviceUniqueIdentifier;
		if (!File.Exists(Path.GetTempPath() + "\\PanoExperiment_" + ss + "\\Identified_Hazards.txt"))
		{
			StartCoroutine(timer());
//			Debug.Log ("File does not exist");
		} 
		else 
		{
			string[] lines = File.ReadAllLines (Path.GetTempPath() + "\\PanoExperiment_" + ss + "\\Identified_Hazards.txt");
			string hazards = string.Join (" ", lines);	
			if (!(hazards.Contains("01_A") && hazards.Contains("02_A") && hazards.Contains("03_A") && hazards.Contains("04_A"))) {
				StartCoroutine(timer());
//				Debug.Log ("You must have enough selections to continue");
			} 
			else 
			{
				SceneManager.LoadScene (sceneToChangeTo);
			}
		}
	}
}
