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

    public static Dictionary<CluesQuestion, string> CluesDictionary = new Dictionary<CluesQuestion, string>();

    public static Flowchart ActiveFlowChart { get; internal set; }
    public static Flowchart BaseFlowChart
    {
        get
        {
            if (baseFlowChart == null)
            {
                // first base flowchart
                List<Flowchart> flowCharts = Flowchart.CachedFlowcharts;
                foreach(Flowchart chart in flowCharts)
                {
                    if(chart.name == baseFlowChartsName)
                    {
                        baseFlowChart = chart;
                        break;
                    }
                }
            }
            return baseFlowChart;
        }
    }
    private static Flowchart baseFlowChart;
    private static string baseFlowChartsName = "Base_Flowchart";

    public static void NotifyFlowChart()
    {
        CheckAndGoToClueDialog();
        UpdateCluesButtons();
    }

    private static void CheckAndGoToClueDialog()
    {
        if (ActiveFlowChart == null) return;

        if (ActiveClue != Clues.None)
        {
            ActiveFlowChart.StopAllBlocks();
            if (ActiveFlowChart.HasBlock(activeClue.ToString()))
            {
                ActiveFlowChart.ExecuteBlock(activeClue.ToString());
            }
            else
            {
                ActiveFlowChart.ExecuteBlock("default");
            }
            ActiveClue = Clues.None;
        }
    }

    public static void UpdateCluesButtons()
    {
        foreach(KeyValuePair<CluesQuestion, string> clue in CluesDictionary)
        {
            clue.Key.gameObject.SetActive(BaseFlowChart.GetBooleanVariable(clue.Value));
        }
    }
    
    public static void HideAllCluesButtons()
    {
        foreach (KeyValuePair<CluesQuestion, string> clue in CluesDictionary)
        {
            clue.Key.gameObject.SetActive(false);
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
