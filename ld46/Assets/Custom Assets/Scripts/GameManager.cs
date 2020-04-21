using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<VariableState> InitialState;
    [SerializeField]
    bool startsAtBeginning;

    // Start is called before the first frame update
    void Start()
    {
        InitializeScene();
    }

    void InitializeScene()
    {
        DialogPromptsManager.HideAllPromptButtons();
        InteractiblesManager.UpdateInteractiblesVisibility();

        if(startsAtBeginning)
        {
            foreach (VariableState variable in InitialState)
            {
                DialogPromptsManager.BaseFlowChart.SetBooleanVariable(variable.name, variable.state);
            }
        }

    }
}

[System.Serializable]
public class VariableState
{
    public string name;
    public bool state;
}