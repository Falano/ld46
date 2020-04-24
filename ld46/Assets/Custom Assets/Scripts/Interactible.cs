using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Interactible : MonoBehaviour
{
    [SerializeField]
    GameObject Sprite;
    [SerializeField]
    BackgroundManager bgManager;

    public Flowchart Flowchart { get; private set; }

    private void Awake()
    {
        InteractiblesManager.InteractiblesList.Add(this);
        Flowchart = GetComponentInChildren<Flowchart>();
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
        bgManager.EnableSpritesColliders();
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
