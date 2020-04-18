using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public static class CluesManager
{
    public static Clues ActiveClue;

    public static bool isBestFriendActive;
    public static bool isSamActive;
    public static bool isPirateActive;
}

public enum Clues
{
    None,
    BestFriend,
    Sam,
    Pirate
}