using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue System/NewDialogue")]
public class DialogueNode : ScriptableObject
{
    public bool npc_mod_React;
    public string dialogueText;
    public NPC_State npc_State;
    public DialogueOption[] responseOptions;

}