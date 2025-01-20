using UnityEngine;
using System;

public static class DialogueEvents
{
    // Event triggered when a player makes a choice
    public static Action<string, int, NPC_State> OnChoiceMade; // (npcName, qiny, playerAnswer)
}

