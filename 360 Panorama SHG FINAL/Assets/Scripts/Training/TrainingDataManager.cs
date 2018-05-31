using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
// using Firebase;
// using Firebase.Database;
// using Firebase.Unity.Editor;

public class TrainingDataManager : PARSDataManager {

    private TrainingController tc;
    
    public TrainingDataManager(string fileName, TrainingController tc) : base(fileName) {
        this.tc = tc;
    }

    public void save() {
        this.addTimesToJson();
        this.addRoundsToJson();
        // jsonOutput += "\n}";
        this.storeToFirebase("0_TrainingResponses");
        this.saveToFile();
    }

    protected void addTimesToJson() {
        this.jsonOutput += "\"startTime\": \"" + tc.startTime.ToString("yyyy-MM-dd\\THH:mm:ss\\Z") + "\",";
		this.jsonOutput += "\"endTime\": \"" + tc.endTime.ToString("yyyy-MM-dd\\THH:mm:ss\\Z")  + "\",";
        Debug.Log(jsonOutput);
    }

    void addRoundsToJson() {
        this.jsonOutput +=  "\"responses\": " + "{";
		foreach (Round round in tc.finishedRounds) {
			jsonOutput += "\n\t\t \"" + round.getSceneID() + "\":" + JsonUtility.ToJson (round) + ",";
		}
        this.jsonOutput += "\n\t}";
        Debug.Log(jsonOutput);
    }


    void storeToFile() {
        Debug.Log("=== STORING TO FILE ===");
        Debug.Log(jsonOutput);

		string filePath = Path.Combine (Application.persistentDataPath, this.gameDataFileName);
		if (File.Exists (filePath)) {
			File.WriteAllText (filePath, this.jsonOutput);
		}
    }
}