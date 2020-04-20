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
    }

    public void SetActiveFlowChart()
    {
        DialogPromptsManager.ActiveFlowChart = this.Flowchart;
        DialogPromptsManager.UpdateDialogPromptButtons();
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
