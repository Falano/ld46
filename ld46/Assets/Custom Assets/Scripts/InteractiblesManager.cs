using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InteractiblesManager
{
    public static List<Interactible> InteractiblesList;

    public static void UpdateInteractiblesVisibility()
    {
        foreach(Interactible inter in InteractiblesList)
        {
            inter.UpdateVisibility();
        }
    }
}
