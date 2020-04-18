using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluesQuestion : MonoBehaviour
{
    [SerializeField]
    private Clues localClue;

    private void OnMouseDown()
    {
        CluesManager.ActiveClue = localClue;
    }
}

