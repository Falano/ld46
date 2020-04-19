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

    public void SetActiveFlowChart()
    {
        CluesManager.ActiveFlowChart = this.Flowchart;
    }
}
