using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingCollectionCell : MonoBehaviour {

	public bool expandingSummaryTextBoxEnabled = true;
	
	string category;
	string name;
	string summaryText;
	Color color;

	TrainingHazardController hazardController;
	private Image cellBackground;
	private Text[] cellLabels;
	private Text categoryLabel;
	private Text nameLabel;
	private Text summaryTextBox;
	Image icon;

	private State currentState;
	private CellPressedCallBack collectionCallBack;

	public void Initialize(TrainingHazardController hazardController) {
		this.hazardController = hazardController;
		var hazard = hazardController.hazard;
		this.category = hazard.category;
		this.name = hazard.name;
		this.summaryText = hazard.summaryText;
		this.color = hazard.color;
		reloadUI();
	}

	void reloadUI() {
		cellBackground = this.GetComponent<Image>();
		cellLabels = this.GetComponentsInChildren<Text>();
		foreach(Text label in cellLabels) {
			switch (label.name) {
				case "CategoryLabel" :
					this.categoryLabel = label;
					this.icon = label.GetComponentInChildren<Image>();
					label.transform.Find("Icon/Icon (1)").gameObject.GetComponent<Image>().color = this.color;
					break;
				case "HazardLabel" :
					this.nameLabel = label;
					break;
				case "SummaryTextBox" :
					this.summaryTextBox = label;
					break;
			}
		}
		categoryLabel.text = "hazard : " + this.category;
		nameLabel.text = this.name;
		summaryTextBox.text = this.summaryText;
		this.summaryTextBox.gameObject.SetActive(false);
		Canvas.ForceUpdateCanvases();
		GetComponent<VerticalLayoutGroup>().enabled = false;
		GetComponent<VerticalLayoutGroup>().enabled = true;
	}

	public void setViewColors(Color backgroundColor, Color textColor) {
		cellBackground.color = backgroundColor;
		foreach	(Text label in cellLabels) {
			label.color = textColor;
		}
	}

	public void setSummaryTextBox(bool isActive){
		if(expandingSummaryTextBoxEnabled && this.summaryText != "") { this.summaryTextBox.gameObject.SetActive(isActive); }
		this.collectionCallBack();
		Canvas.ForceUpdateCanvases();
		GetComponent<VerticalLayoutGroup>().enabled = false;
		GetComponent<VerticalLayoutGroup>().enabled = true;
	}

	// Public Event Delegate Method
	public void pressed() {
		State newState = this.hazardController.ToggleState();
	}

	// Public Collection Delegate Setter Method
	public void setCollectionCallback(CellPressedCallBack callback) {
		this.collectionCallBack = callback;
	}
}
