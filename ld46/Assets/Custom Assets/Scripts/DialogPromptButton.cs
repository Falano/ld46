using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPromptButton : MonoBehaviour
{
    [SerializeField]
    private DialogPrompts localDialogPrompt;
    public DialogPrompts LocalDialogPrompt { get => localDialogPrompt; }
    [SerializeField]
    private string FungusDialogPromptName;

    private void Awake()
    {
        DialogPromptsManager.DialogPromptsDictionary.Add(this, FungusDialogPromptName);
    }
    private void Start()
    {
        if (!DialogPromptsManager.BaseFlowChart.HasVariable(FungusDialogPromptName))
        {
            Debug.LogError("The variable " + FungusDialogPromptName + " doesn't exist for Clue " + LocalDialogPrompt);
        }
    }

    public void Prompt()
    {
        DialogPromptsManager.ActivePrompt = localDialogPrompt;
    }
}

