using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class URL_Access_Conditional : MonoBehaviour {

	public GameObject kk;

	void Start (){
		kk.gameObject.SetActive(false);
	}

	public void TaskOnClick () {
		Application.OpenURL("https://www.qualtrics.com/homepage/");
		kk.gameObject.SetActive(true);

//		string ss = SystemInfo.deviceUniqueIdentifier;
//		if (System.IO.File.Exists(Path.GetTempPath () + "\\PanoExperiment_" + ss + "\\Demographics.txt")){
//			Debug.Log ("IT WORKS!");
//			kk.gameObject.SetActive(true);
//		} 
//		else{
//			kk.gameObject.SetActive(false);
//		}



	}
}
