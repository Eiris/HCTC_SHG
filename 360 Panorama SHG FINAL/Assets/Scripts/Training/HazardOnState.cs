using UnityEngine;
using UnityEngine.UI;

public class HazardOnState : State
{
    private Vector3 destination;

    public HazardOnState(TrainingHazardController hazardController) : base(hazardController)
    {
    }

    public override void OnStateEnter()
    {
        Color backgroundColor = new Color(0F, 0.322F, 0.608F, 1F);
        // Color backgroundColor = Color.blue;
        Color textColor = Color.white;
        hazardController.icon.renderToggleOn();
        hazardController.content.setContentVisibilty(true);
        hazardController.cell.setViewColors(backgroundColor, textColor);
        hazardController.cell.setSummaryTextBox(true);

        // hazardCell.spriteController.GetComponent<HazardSpriteController>().setOn();
        if(!hazardController.icon.isInView) {
            Camera.main.GetComponent<CameraMovement>().LookTowards(hazardController.icon.transform);
        }

    }

}

public class HazardOffState : State
{
    private Vector3 destination;

    public HazardOffState(TrainingHazardController hazardController) : base(hazardController)
    {
    }

    public override void OnStateEnter()
    {
        Color backgroundColor = Color.white;
        // Color textColor = new Color(106F, 109F, 114F);
        Color textColor = Color.gray;
        hazardController.icon.renderToggleOff();
        hazardController.content.setContentVisibilty(false);
        hazardController.cell.setViewColors(backgroundColor, textColor);
        hazardController.cell.setSummaryTextBox(false);

        // hazardCell.spriteController.GetComponent<HazardSpriteController>().setOff();


    }

}

public abstract class State
{
    protected TrainingHazardController hazardController;

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public State(TrainingHazardController hazard)
    {
        this.hazardController = hazard;
    }
}