using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void CellPressedCallBack();

public class TrainingCollectionController : MonoBehaviour {

	public GameObject HazardCell;

	public TrainingCollectionCell addCell(TrainingHazardController hazardController) {
		var newCell = Instantiate(HazardCell, transform);
		newCell.transform.SetParent(transform, false);
		var newCellController = newCell.GetComponent<TrainingCollectionCell>();
		newCellController.setCollectionCallback((CellPressedCallBack)this.cellPressed);
		newCellController.Initialize(hazardController);
		Canvas.ForceUpdateCanvases();
		GetComponent<VerticalLayoutGroup>().enabled = false;
		GetComponent<VerticalLayoutGroup>().enabled = true;
		return newCellController;
	}

	public void cellPressed() {
		print("Cell Pressed in parent");
		Canvas.ForceUpdateCanvases();
		GetComponent<VerticalLayoutGroup>().enabled = false;
		GetComponent<VerticalLayoutGroup>().enabled = true;
	}

	public void removeAllCells() {
		for (int i = 0; i < this.transform.childCount; i++) {		
			print("WOOWOW");
			GameObject.Destroy(transform.GetChild(i).gameObject);
		}
	}
}
