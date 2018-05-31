using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ionic.Zip;
using System.IO;

public class Zip_Folder : MonoBehaviour {

	public void Zip_File(){
		using (ZipFile zip = new ZipFile ()) {

			string ss = SystemInfo.deviceUniqueIdentifier;
			zip.AddDirectory (Path.GetTempPath () + "\\PanoExperiment_" + ss);
//			zip.AddFile ("PanoExperiment_" + ss, );
			zip.Save (Path.GetTempPath () + "\\PanoExperiment_" + ss + ".zip");
//			zip.Dispose ();
		}
	}
}
