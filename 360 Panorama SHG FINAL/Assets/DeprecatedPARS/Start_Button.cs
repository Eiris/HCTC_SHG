using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Start_Button : MonoBehaviour 
{

	public void MoveFile_Start()
	{
		string ss = SystemInfo.deviceUniqueIdentifier;
		string result = Path.GetTempPath()  + "\\PanoExperiment_"+ss ;
		System.IO.Directory.CreateDirectory (result);
//		Debug.Log (ss);

	}
}
