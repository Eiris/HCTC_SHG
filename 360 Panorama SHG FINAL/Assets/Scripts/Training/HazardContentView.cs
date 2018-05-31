using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HazardContentView : MonoBehaviour {

	private SpriteRenderer[] sprites;
	private HazardSummary summary;

	// Use this for initialization
	void Start () {
		this.sprites = this.GetComponentsInChildren<SpriteRenderer>();
	}

	public void setContentVisibilty(bool enabled) {
		this.gameObject.SetActive(enabled);
	}
}
