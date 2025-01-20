using TMPro;
using UnityEngine;

public class NPCDialogueChecker : MonoBehaviour
{
    public string npcId;                     // Unique identifier for this NPC

    [SerializeField]
    public TMP_Text text;                    // Text component for NPC dialogue display
    public bool React;

    [SerializeField]
    private DialogueStateManager stateManager; // Reference to the DialogueStateManager

    private void Update()
    {
        // Debug check for NPC IDs starting with "M"
        /*if ( React == true && npcId.StartsWith("M"))
        {
            Debug.Log($"NPC ID starts with M: {npcId}");
            // Uncomment to automatically check dialogue on Update
            // CheckDialogue();
        }*/


    }

    public void CheckDialogue()
    {
        // Check if there is a response from the "Boss" NPC
        if (stateManager.HasResponse("Boss") && React == true && npcId.StartsWith("M"))
        {
            DialogueState state = stateManager.GetLatestResponse("Boss");
            Debug.Log($"NPC {npcId} remembers: 'Boss says {state.responseText}' with emotion {state.npc_State}");

            // React to the player's emotion
            ReactToEmotion(state.npc_State);
        }
        else
        {
            Debug.Log($"NPC {npcId} has no memory of the player's response.");
            if (text != null)
            {
                text.text = $"NPC {npcId} says: 'I have no memory of Boss's words.'";
            }
        }
    }

    private void ReactToEmotion(NPC_State playerEmotion)
    {
        if (text != null)
        {
            switch (playerEmotion)
            {
                case NPC_State.IDLE:
                    text.text = $"NPC {npcId} reacts: 'I’m glad you’re calm.'";
                    Debug.Log($"NPC {npcId} reacts: 'I’m glad you’re calm.'");
                    break;

                case NPC_State.DEATH:
                    text.text = $"NPC {npcId} reacts: 'That sounds tragic.'";
                    Debug.Log($"NPC {npcId} reacts: 'That sounds tragic.'");
                    break;

                case NPC_State.ATTACK:
                    text.text = $"NPC {npcId} reacts: 'That sounds intense!'";
                    Debug.Log($"NPC {npcId} reacts: 'That sounds intense!'");
                    break;

                case NPC_State.HIT:
                    text.text = $"NPC {npcId} reacts: 'I hope you’re okay.'";
                    Debug.Log($"NPC {npcId} reacts: 'I hope you’re okay.'");
                    break;

                default:
                    text.text = $"NPC {npcId} reacts: 'I see.'";
                    Debug.Log($"NPC {npcId} reacts: 'I see.'");
                    break;
            }
        }
        else
        {
            Debug.LogError("No Text component is assigned to display NPC reaction.");
        }
    }
}
