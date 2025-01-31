using UnityEngine;

[System.Serializable]
public class DialogueOption
{
    public string PlayerText;
    public string overallText;
    public NPC_State playerEmotion;
    public DialogueNode[] NPC_Choices;
}

