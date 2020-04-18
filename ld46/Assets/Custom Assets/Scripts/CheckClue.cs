using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CheckClue : MonoBehaviour
{
    public Flowchart Flowchart { get; private set; }

    private void Start()
    {
        Flowchart = gameObject.GetComponent<Flowchart>();
    }


    public void CheckForClues()
    {
        if(CluesManager.ActiveClue != Clues.None)
        {
            Flowchart.StopAllBlocks();
            Flowchart.ExecuteBlock(CluesManager.ActiveClue.ToString());
            CluesManager.ActiveClue = Clues.None;
        }
        DownloadAvailableCluesFromFungus();
    }


    public void DownloadAvailableCluesFromFungus()
    {
        CluesManager.isBestFriendActive = Flowchart.GetBooleanVariable("BestFriend");
        CluesManager.isPirateActive = Flowchart.GetBooleanVariable("Pirate");
        CluesManager.isSamActive = Flowchart.GetBooleanVariable("Sam");
    }

    public void UploadAvailableCluesToFungus()
    {
        Flowchart.SetBooleanVariable("BestFriend", CluesManager.isBestFriendActive);
        Flowchart.SetBooleanVariable("Pirate", CluesManager.isPirateActive);
        Flowchart.SetBooleanVariable("Sam", CluesManager.isSamActive);
    }

}
