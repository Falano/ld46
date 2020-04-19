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
    }

    private void OnMouseDown()
    {
        CluesManager.ActiveClue = localClue;
    }
}

