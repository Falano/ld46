using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InteractiblesManager
{
    public static List<Interactible> InteractiblesList = new List<Interactible>();

    public static void UpdateInteractiblesVisibility()
    {
        foreach(Interactible inter in InteractiblesList)
        {
            inter.UpdateVisibility();
        }
    }
}
