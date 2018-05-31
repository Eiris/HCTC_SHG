using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssessmentPanelController : MonoBehaviour {

	GameObject collectionView;

	// Use this for initialization
	void Start () {
		collectionView = GameObject.FindGameObjectWithTag ("Collection");	
		GameObject temp = (GameObject)Instantiate (Resources.Load ("Prefabs/CategoryCell"));
		temp.transform.parent = collectionView.transform;
		temp.transform.localScale =  new Vector3 (1f, 1f, 1f);
	}
}
