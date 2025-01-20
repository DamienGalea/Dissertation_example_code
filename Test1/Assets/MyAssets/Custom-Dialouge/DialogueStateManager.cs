using UnityEngine;
using System.Collections.Generic;

public class DialogueStateManager : MonoBehaviour
{
    public static DialogueStateManager Instance { get; private set; }

    private Dictionary<string, List<DialogueState>> dialogueHistory = new Dictionary<string, List<DialogueState>>();

    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    
    // Save a player's response and NPC state for a specific NPC
    public void SaveResponse(string npcId, string responseText, NPC_State npc_State)
    {
        if (!dialogueHistory.ContainsKey(npcId))
        {
            dialogueHistory[npcId] = new List<DialogueState>();
        }

        // Add the new response to the conversation history
        dialogueHistory[npcId].Add(new DialogueState(responseText, npc_State));

        Debug.Log($"Saved response for NPC: {npcId} - Response: {responseText} - NPC_State: {npc_State} 2323232");
    }

    public DialogueState GetLatestResponse(string npcId)
    {
        if (dialogueHistory.ContainsKey(npcId) && dialogueHistory[npcId].Count > 0)
        {
            // Return the most recent dialogue state
            return dialogueHistory[npcId][dialogueHistory[npcId].Count - 1];
        }
        return null;
    }

    public List<DialogueState> GetAllResponses(string npcId)
    {
        if (dialogueHistory.ContainsKey(npcId))
        {
            return dialogueHistory[npcId];
        }
        return null;
    }

    public bool HasResponse(string npcId)
    {
        return dialogueHistory.ContainsKey(npcId) && dialogueHistory[npcId].Count > 0;
    }
}

[System.Serializable]
public class DialogueState
{
    public string responseText;       // Player's response text
    public NPC_State npc_State;    // Player's emotion

    public DialogueState(string responseText, NPC_State npc_State)
    {
        this.responseText = responseText;
        this.npc_State = npc_State;
    }
}