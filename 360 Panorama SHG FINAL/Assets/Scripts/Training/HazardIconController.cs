using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardIconController : MonoBehaviour {

	TrainingHazardController parentController;
	Color color;
	public SpriteRenderer fill;
	public SpriteRenderer outline;
	public bool isInView;

	void Start () {
		this.parentController = transform.parent.GetComponent<TrainingHazardController>();
		this.transform.LookAt(Camera.main.transform);
	}
	
	void Update () {
		Vector3 viewPoint = Camera.main.WorldToViewportPoint(transform.position);
		isInView = viewPoint.z > 0 && viewPoint.x > 0.1 && viewPoint.x < 0.9 && viewPoint.y > 0.1 && viewPoint.y < 0.9;
		if(!isInView && !Camera.main.GetComponent<CameraMovement>().lerping) {
			parentController.SetStateOff();
		}
	}

	public void setColor(Color color) {
		this.color = color;
	}

	void OnMouseDown() {
		parentController.ToggleState();
	}

	public void renderToggleOn() {
		fill.color = Color.white;
		outline.color = this.color;
	}

	public void renderToggleOff(){
		fill.color = this.color;
		outline.color = Color.white;
	}
}
