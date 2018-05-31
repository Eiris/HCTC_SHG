using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultAnswersList : MonoBehaviour {

	public GameObject listItem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void populateList(string[] stringItems) {
		foreach (string item in stringItems) {
			var li = Instantiate(listItem, transform);
			li.transform.parent = transform;
			li.GetComponent<Text>().text = "- " + item;
		}
		Canvas.ForceUpdateCanvases();
		GetComponent<VerticalLayoutGroup>().enabled = false;
		GetComponent<VerticalLayoutGroup>().enabled = true;
	}

	public void populateCorrectList(string[] stringItems, string[] key) {
		List<string> searchableKey = new List<string>(key);
		foreach (string item in stringItems) {
			var li = Instantiate(listItem, transform);
			li.transform.parent = transform;
			li.GetComponent<Text>().text = "- " + item;
			if(searchableKey.Contains(item)) {
				li.GetComponent<Text>().color = new Color(0.08f, 0.6f, 0f);
			} else {
				li.GetComponent<Text>().color = Color.red;
			}
		}
		Canvas.ForceUpdateCanvases();
		GetComponent<VerticalLayoutGroup>().enabled = false;
		GetComponent<VerticalLayoutGroup>().enabled = true;
	}
}
