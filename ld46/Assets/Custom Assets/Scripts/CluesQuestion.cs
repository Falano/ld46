using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluesQuestion : MonoBehaviour
{
    [SerializeField]
    private Clues localClue;
    public Clues LocalClue { get => localClue; }
    [SerializeField]
    private string FungusClueName;

    private void Start()
    {
        CluesManager.CluesDictionary.Add(this, FungusClueName);

        if (!CluesManager.BaseFlowChart.HasVariable(FungusClueName))
        {
            Debug.LogError("The variable " + FungusClueName + " doesn't exist for Clue " + LocalClue);
        }
    }

    private void OnMouseDown()
    {
        CluesManager.ActiveClue = localClue;
    }
}

