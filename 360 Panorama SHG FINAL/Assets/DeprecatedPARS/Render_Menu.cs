using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Render_Menu : MonoBehaviour {

	//Get object
	public GameObject panel_1;
	public GameObject panel_2;
	public GameObject panel_3;
//	public bool on_off;

	public void Render_object(){
		if (gameObject.activeSelf == false && panel_1.activeSelf == false && panel_2.activeSelf == false && panel_3.activeSelf == false) {
			gameObject.SetActive (true);
		} else {
			gameObject.SetActive (false);
		}
	}
}
