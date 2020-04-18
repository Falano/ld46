using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluesQuestion : MonoBehaviour
{
    public static Clues ActiveClue;

    [SerializeField]
    private Clues localClue;


    private void OnMouseDown()
    {
        ActiveClue = localClue;
    }
}

public enum Clues
{
    None,
    Sam,
    Pirate
}
