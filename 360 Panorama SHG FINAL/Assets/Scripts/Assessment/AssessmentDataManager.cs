using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class PARSDataManager
{
	private string sessionID;
	private static PARSDataManager instance;
	protected string gameDataFileName;
	// private DatabaseReference reference;
	protected string jsonOutput;
	private string sessionStart;

	public PARSDataManager(string fileName){
		instance = this;
		this.sessionID = PlayerPrefs.GetString("studyID") + "-" + PlayerPrefs.GetString("demographic")[0] + "_" +  SystemInfo.deviceUniqueIdentifier;
		Debug.Log(this.sessionID);
		this.sessionStart = System.DateTime.Now.ToString("yyyy-MM-dd\\THH:mm:ss\\Z");
		this.gameDataFileName = fileName;
		this.jsonOutput = "{";

		// Firebase Code
		// #if UNITY_EDITOR 
		// 	FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(Settings.s.fireBaseURL);
		// #else	
		// 	FirebaseApp.DefaultInstance.Options.DatabaseUrl = new System.Uri(Settings.s.fireBaseURL);
		// #endif
		// this.reference = FirebaseDatabase.DefaultInstance.RootReference;
	}

	public void saveRounds(List<Round> rounds) {
		this.jsonOutput = this.jsonOutput + this.roundsToJson(rounds);
	}

	public void saveAssessmentTime(DateTime startTime, DateTime endTime) {
		this.jsonOutput = this.jsonOutput + "\"startTime\": \"" + startTime.ToString("yyyy-MM-dd\\THH:mm:ss\\Z") + "\",";
		this.jsonOutput = this.jsonOutput + "\"endTime\": \"" + endTime.ToString("yyyy-MM-dd\\THH:mm:ss\\Z")  + "\",";
	}

	public void saveToFile() {
		jsonOutput += "\n}";
		this.saveToFile(jsonOutput);
		// Firebase Code
		// reference.Child("0_AssessmentResponses").Child(this.sessionID).Child(this.sessionStart).SetRawJsonValueAsync(jsonOutput);
	}

	string roundsToJson(List<Round> rounds){
		string jsonOutput =  "\n\t\t\"responses\": " + "{";
		foreach (AssessmentRound round in rounds) {
			jsonOutput += "\n\t\t\t \"" + round.getSceneID() + "\":" + JsonUtility.ToJson (round) + ",";
		}
		jsonOutput += "\n\t\t}";
		return jsonOutput;
	}

	private void saveToFile(string input){
		string filePath = Path.Combine (Application.persistentDataPath, this.gameDataFileName);
		Debug.Log("FILE: " + filePath);
		Debug.Log("Saving to FILE: " + input);
		Debug.Log("File Exists: " + File.Exists (filePath));
		Debug.Log((File.Exists(filePath)) ? ",\n" : "");

		string[] fullJSONOutput;
		if (!File.Exists(filePath)) {
			using (var stream = File.Create(filePath)) { }
			fullJSONOutput = new string[]{"[\n" + "{\"" + this.sessionID + "\":\n\t" + input + "}" + "\n]"};
		} else {
			var lines = File.ReadAllLines(filePath);
			List<String> linesList = new List<String>(lines);
			linesList.RemoveAt(linesList.Count - 1);
			// lines[lines.Length-1] = "";
			string partJSONOoutput = ",\n" + "{\"" + this.sessionID + "\":\n\t" + input + "}"  + "\n]";
			linesList.Add(partJSONOoutput);
			fullJSONOutput = linesList.ToArray();
			Debug.Log(fullJSONOutput);
		}

		File.WriteAllLines(filePath, fullJSONOutput);

		// lines[lines.Length-1] = "";

		


		// using(StreamWriter sw = File.AppendText(filePath)) {
			
		// 	sw.Write(fullJSONOutput);
		// }
	}

	protected void storeToFirebase(string keyLocation) {			
			// Firebase Code
        	// reference.Child(keyLocation).Child(this.sessionID).Child(this.sessionStart).SetRawJsonValueAsync(jsonOutput);
    }

	public AnswerKey retrieveAnswers(Action<Question[]> populationMethod) {
		// AnswerKey answerKey = null;
		TextAsset textAsset = (TextAsset)Resources.Load("1_AssessmentAnswers");
		Debug.Log(textAsset);
		string jsonInput = textAsset.text;
		Question[] questions = JsonHelper.getJsonArray<Question>(jsonInput);
		populationMethod(questions);

		// Firebase Code
		// var questionsTask = reference.Child("1_AssessmentAnswers").GetValueAsync()
		// 	.ContinueWith(task => {
		// 		//  taskAnswerKey = null;
		// 		if (task.IsFaulted) {
		// 		// Handle the error...
		// 			// taskAnswerKey = null;
		// 		}
		// 		else if (task.IsCompleted) {
		// 			DataSnapshot snapshot = task.Result;
		// 			Dictionary<string, object> hello = snapshot.GetValue(true) as Dictionary<string, object>;
		// 			string jsonInput = snapshot.GetRawJsonValue();
		// 			Question[] questions = JsonHelper.getJsonArray<Question>(jsonInput);
		// 			// AnswerKey taskAnswerKey = new AnswerKey(questions);
		// 			// Debug.Log(taskAnswerKey.dictionary.Count);
		// 			populationMethod(questions);
		// 		}
		// 	});
		// // AnswerKey answerKey = questionsTask.Result as AnswerKey;
		// Debug.Log(questionsTask.IsCompleted);
		return null;
	}
}

public class JsonHelper
{
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (newJson);
        return wrapper.array;
    }
 
    [Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}