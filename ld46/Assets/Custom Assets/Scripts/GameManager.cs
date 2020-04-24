using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<VariableState> InitialState;
    [SerializeField]
    List<CharacterAvailability> InitialCharacters;
    [SerializeField]
    bool startsAtBeginning;
    [SerializeField]
    BackgroundManager bgManager;

    // Start is called before the first frame update
    void Start()
    {
        InitializeScene();
    }

    public void InitializeScene()
    {
        bgManager.SetDefaultBackground();
        bgManager.DisableSpritesColliders();
        DialogPromptsManager.HideAllPromptButtons();
        InteractiblesManager.UpdateInteractiblesVisibility();

        if (DialogPromptsManager.ActiveFlowChart)
        {
            DialogPromptsManager.ActiveFlowChart.StopAllBlocks();
        }
        else
        {
            DialogPromptsManager.StartFlowChart.StopAllBlocks();
        }

        if (startsAtBeginning || !Application.isEditor)
        {
            foreach (VariableState variable in InitialState)
            {
                DialogPromptsManager.BaseFlowChart.SetBooleanVariable(variable.name, variable.state);
            }

            foreach (CharacterAvailability chara in InitialCharacters)
            {
                chara.flowchart.SetBooleanVariable("isAvailable", chara.isAvailable);
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

[System.Serializable]
public class VariableState
{
    public string name;
    public bool state;
}

[System.Serializable]
public class CharacterAvailability
{
    public Fungus.Flowchart flowchart;
    public bool isAvailable;
}