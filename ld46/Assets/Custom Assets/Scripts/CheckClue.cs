using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CheckClue : MonoBehaviour
{
    Flowchart Flowchart;

    private void Start()
    {
        Flowchart = gameObject.GetComponent<Flowchart>();
    }

    public void CheckForClues()
    {
        switch (Flowchart.GetStringVariable("ActiveCharacter"))
        {
            case "MusicListener":
                switch (Flowchart.GetStringVariable("ActiveClue"))
                {
                    case "Sam":
                        Flowchart.SetStringVariable("ActiveClue", "");
                        Flowchart.StopAllBlocks();
                        Flowchart.ExecuteBlock("Music Listener - Sam (Copy)1");
                        break;
                    case "Pirate":
                        Flowchart.SetStringVariable("ActiveClue", "");
                        Flowchart.StopAllBlocks();
                        Flowchart.ExecuteBlock("Music Listener - Pirate (Copy)1");
                        break;
                    default:
                        break;
                }
                break;
        }
    }

    public void CheckForClues2()
    {
        if(CluesQuestion.ActiveClue != Clues.None)
        {
            Flowchart.StopAllBlocks();
            Flowchart.ExecuteBlock(CluesQuestion.ActiveClue.ToString());
            CluesQuestion.ActiveClue = Clues.None;
        }
    }

}
