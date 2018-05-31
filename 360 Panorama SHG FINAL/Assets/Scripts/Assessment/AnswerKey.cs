using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

[Serializable]
public class Question {
	public string key;
	public string[] answers;
}

[Serializable]
public class AnswerKey {
	public Dictionary<string, string[]> dictionary;

	public AnswerKey(Question[] questions) {
		this.dictionary = new Dictionary<string, string[]>();
		foreach (Question question in questions) {
			this.dictionary.Add(question.key, question.answers);
		}
	}
	
	public float gradeForRound(Round round) {
		string[] answers = this.dictionary[round.getSceneID()];
		float maxScore = answers.Length;
		float correctResponseCount = 0;
		foreach(Hazard response in round.hazardResponses) {
			if(answers.Contains(response.name)) {
				correctResponseCount++;
			} else {
				// TODO : what happens if they over-guess? If one of their responses was NOT in the answers?
				// correctResponseCount--;
				// correctResponseCount -= correctResponseCount / 2;
			}
		}
		return correctResponseCount / maxScore * 100;
	}
}

