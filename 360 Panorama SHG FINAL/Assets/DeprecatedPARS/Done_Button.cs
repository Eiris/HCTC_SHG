using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Done_Button : MonoBehaviour 
{
	public void MoveFile(){
		
		//String variables for the path directories of my files --> Dynamically generated at the computer temp folder --> TEMP ONLY
		string ss = SystemInfo.deviceUniqueIdentifier;
		string sourcefile1 = Path.GetTempPath()  + "\\PanoExperiment_" + ss + "\\Identified_Hazards.txt"; // C:\Users\UserName\AppData\Local\Temp\ + Hazards.txt
		string sourcePath = Path.GetTempPath() + "\\PanoExperiment_" + ss;
		string targetPath = Path.GetTempPath() + "\\PanoExperiment_" + ss + "\\User0"; // C:\Users\UserName\AppData\Local\Temp\ + User0.txt

		//If the folder does not exist in the targetpath, create one
		if(!System.IO.Directory.Exists(targetPath)){
			Directory.CreateDirectory(targetPath);
			File.Move (sourcefile1, (targetPath+"\\Identified_Hazards.txt"));
		} 

		//Else, find the last folder created in the directory and add a new number to the string
		else
		{
			//creating a list that contains all the paths of the folders in the directory by evaluating the time they were written
			List<string> pathwanted = new List<string> ();
			DateTime lastHigh = new DateTime (1900, 1, 1);
			string highDir;
			foreach (string subdir in Directory.GetDirectories(sourcePath)) 
			{
				DirectoryInfo fi1 = new DirectoryInfo (subdir);
				DateTime created = fi1.LastWriteTime;

				if (created > lastHigh) 
				{
					highDir = subdir;
					lastHigh = created;
					pathwanted.Add (highDir);
				}
			}

			//using the last item in the list (pathwanted[pathwanted.Count -1), add a number to the string
			string s = pathwanted [pathwanted.Count - 1];
			char last_cs = s[s.Length- 1];
			int new_i = ((last_cs - '0') + 1);
			string new_s = new_i.ToString ();
			string newpath = s.Remove (s.Length - 1, 1) + new_s;
			System.IO.Directory.CreateDirectory(newpath);
			System.IO.File.Move (sourcefile1, (newpath+"\\Identified_Hazards.txt"));
		}
    }		
}
