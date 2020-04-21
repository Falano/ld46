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
    [SerializeField]
    BackgroundManager bgManager;

    private void Awake()
    {
        InteractiblesManager.InteractiblesList.Add(this);
    }

    public void SetActiveFlowChart()
    {
        bgManager.DisableSpritesColliders();
        DialogPromptsManager.ActiveFlowChart = this.Flowchart;
        DialogPromptsManager.UpdateDialogPromptButtons();
        InteractiblesManager.UpdateInteractiblesVisibility(); // to remove once we're sure that every end of dialog passes through LeaveFlowchart()
    }

    public void LeaveFlowchart()
    {
        InteractiblesManager.UpdateInteractiblesVisibility();
        DialogPromptsManager.HideAllPromptButtons();
    }

    public void UpdateVisibility()
    {
        if(Sprite != null)
        {
            Sprite.SetActive(Flowchart.GetBooleanVariable("isAvailable"));
        }
    }
}
