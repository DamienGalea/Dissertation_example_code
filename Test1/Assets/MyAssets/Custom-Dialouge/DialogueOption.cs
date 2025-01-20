using UnityEngine;

[System.Serializable]
public class DialogueOption
{
    public string responseText;
    public string overallText;
    public NPC_State playerEmotion;
    
    public DialogueNode nextNode; // Reference to the next dialogue node
    public DialogueNode[] NPCnodes;
}

