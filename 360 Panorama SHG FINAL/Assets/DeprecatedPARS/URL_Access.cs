using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class URL_Access : MonoBehaviour {

	public GameObject kk;

	void Start (){
		kk.gameObject.SetActive(false);
	}

	public void TaskOnClick () {
		Application.OpenURL("https://www.qualtrics.com/homepage/");
		kk.gameObject.SetActive(true);
	}
}
