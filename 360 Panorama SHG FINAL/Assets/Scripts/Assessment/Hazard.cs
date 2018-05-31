using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[Serializable]
public class Hazard {
	public string category;
	public string name;

	public Hazard(string category, string name) {
		this.category = category;
		this.name = name;
	}
}
