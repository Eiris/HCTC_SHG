using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Render_Button : MonoBehaviour {

	public GameObject button;

	void Start (){
		button.gameObject.SetActive(false);

	}
		
	public void showButton(){
		button.gameObject.SetActive(true);

	}
}
