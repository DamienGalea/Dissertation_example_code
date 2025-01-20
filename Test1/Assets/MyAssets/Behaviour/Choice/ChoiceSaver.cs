using UnityEngine;

public class ChoiceSaver : MonoBehaviour
{
    [SerializeField] private Voice_Interaction interaction; // Assign the ScriptableObject in the Inspector

    public void OnEnable()
    {
        // Subscribe to the OnChoiceMade event
        DialogueEvents.OnChoiceMade += SaveChoice;
    }

    public void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        DialogueEvents.OnChoiceMade -= SaveChoice;
    }

    public void SaveChoice(string npcName, int InteractionNumber, NPC_State playerAnswer)
    {
        if (interaction != null)
        {
            // Save the choice into the ScriptableObject
            interaction.AddChoice(npcName, InteractionNumber, playerAnswer);
            Debug.Log($"Choice saved: {playerAnswer} for {npcName} ({InteractionNumber})");
        }
        else
        {
            Debug.LogError("PlayerChoices ScriptableObject is not assigned!");
        }
    }
}
