using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public static class DialogPromptsManager
{
    public static DialogPrompts ActivePrompt
    {
        get
        {
            return activePrompt;
        }

        set
        {
            activePrompt = value;
            NotifyFlowChart();
        }
    }

    private static DialogPrompts activePrompt;

    public static Dictionary<DialogPromptButton, string> DialogPromptsDictionary = new Dictionary<DialogPromptButton, string>();

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

    private static void NotifyFlowChart()
    {
        CheckAndGoToDialog();
    }

    private static void CheckAndGoToDialog()
    {
        if (ActiveFlowChart == null) return;

        // if we have an active clue we switch dialog
        if (ActivePrompt != DialogPrompts.None)
        {
            ActiveFlowChart.StopAllBlocks();
            
            if (ActiveFlowChart.HasBlock(activePrompt.ToString()))
            {
                ActiveFlowChart.ExecuteBlock(activePrompt.ToString());
            }
            else if(ActivePrompt == DialogPrompts.Leave)
            {
                BaseFlowChart.ExecuteBlock(activePrompt.ToString());
            }
            else
            {
                ActiveFlowChart.ExecuteBlock("default");
            }
            ActivePrompt = DialogPrompts.None;
        }
    }

    public static void UpdateDialogPromptButtons()
    {
        foreach(KeyValuePair<DialogPromptButton, string> prompt in DialogPromptsDictionary)
        {
            if (BaseFlowChart.HasVariable(prompt.Value))
            {
                prompt.Key.gameObject.SetActive(BaseFlowChart.GetBooleanVariable(prompt.Value));
            }
        }
    }
    
    public static void HideAllPromptButtons()
    {
        foreach (KeyValuePair<DialogPromptButton, string> prompt in DialogPromptsDictionary)
        {
            prompt.Key.gameObject.SetActive(false);
        }
    }
}

public enum DialogPrompts
{
    None,
    Sam,
    Pirate,
    Cat,
    Bike,
    PlayMusic,
    PhoneNumber,
    Blog,
    BlogContactForm,
    Leave
}
