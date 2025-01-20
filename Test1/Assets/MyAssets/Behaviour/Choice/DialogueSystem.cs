using UnityEngine;

public class DialogueSystem : MonoBehaviour
{

    string npcName;
    int InteractionNumber;
    NPC_State playerAnswer;

    public void PlayerMakesChoice()
    {
        // Trigger the OnChoiceMade event
        DialogueEvents.OnChoiceMade?.Invoke(npcName, InteractionNumber, playerAnswer);
        Debug.Log($"Player chose: {playerAnswer} for {npcName} ({InteractionNumber})");
    }

    public void name(string _npcName)
    {
        npcName = _npcName;
        
    }

    public void question(int _interactionNumber)
    {
        InteractionNumber = _interactionNumber;
    }

    public void answer(NPC_State _playerAnswer)
    {

        playerAnswer = _playerAnswer;
    }
}
