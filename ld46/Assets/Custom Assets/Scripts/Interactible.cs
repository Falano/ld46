using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Interactible : MonoBehaviour
{
    public Flowchart Flowchart { get; private set; }
    //public GameObject Sprite { get; private set; }

    private void Start()
    {
        Flowchart = gameObject.GetComponent<Flowchart>();
        //Sprite = gameObject.GetComponentInChildren<Clickable2D>().gameObject;
    }

    public void SetActiveFlowChart()
    {
        DialogPromptsManager.ActiveFlowChart = this.Flowchart;
        DialogPromptsManager.UpdateDialogPromptButtons();
    }
    
    public void UpdateVisibility()
    {
        //Sprite.SetActive(Flowchart.GetBooleanVariable("isAvailable"));
    }
}
