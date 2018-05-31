using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[Serializable]
public class AssessmentRound : Round
{
	private string sceneID;
	public float HIIScore;

	public AssessmentRound(string sceneID) : base(sceneID){
	}
}
