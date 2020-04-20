using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Interactible : MonoBehaviour
{
    [SerializeField]
    Flowchart Flowchart;
    [SerializeField]
    GameObject Sprite;

    private void Start()
    {
        InteractiblesManager.InteractiblesList.Add(this);
        DialogPromptsManager.UpdateDialogPromptButtons();
        InteractiblesManager.UpdateInteractiblesVisibility();
    }

    public void SetActiveFlowChart()
    {
        DialogPromptsManager.ActiveFlowChart = this.Flowchart;
        DialogPromptsManager.UpdateDialogPromptButtons();
        InteractiblesManager.UpdateInteractiblesVisibility();
    }

    public void LeaveFlowchart()
    {
        InteractiblesManager.UpdateInteractiblesVisibility();
    }

    public void UpdateVisibility()
    {
        if(Sprite != null)
        {
            Sprite.SetActive(Flowchart.GetBooleanVariable("isAvailable"));
        }
    }
}
