using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public static class CluesManager
{
    public static Clues ActiveClue
    {
        get
        {
            return activeClue;
        }

        set
        {
            activeClue = value;
            NotifyFlowChart();
        }
    }

    private static Clues activeClue;

    public static bool isBestFriendActive;
    public static bool isSamActive;
    public static bool isPirateActive;

    public static Flowchart ActiveFlowChart { get; internal set; }

    public static void NotifyFlowChart()
    {
        if (ActiveFlowChart == null) return;

        if (ActiveClue != Clues.None)
        {
            ActiveFlowChart.StopAllBlocks();
            if (ActiveFlowChart.HasBlock(activeClue.ToString()))
            {
                ActiveFlowChart.ExecuteBlock(activeClue.ToString());
            }
            else {
                ActiveFlowChart.ExecuteBlock("default");
            }
            ActiveClue = Clues.None;
        }

    }
}

public enum Clues
{
    None,
    Sam,
    Pirate,
    Cat,
    Bike,
    PlayMusic,
    PhoneNumber,
    MusicBlog,
    BlogContactForm
}
