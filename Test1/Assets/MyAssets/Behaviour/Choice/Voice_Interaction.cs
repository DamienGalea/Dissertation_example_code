using UnityEngine;
using System;                      
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Interaction_Data", menuName = "Dialogue System/Interaction_Data")]
public class Voice_Interaction : ScriptableObject
{
    

    [System.Serializable]
    public class Choice
    {
        public string npcName;
        public int InteractionNumber;
        public NPC_State playerAnswer;
    }

    public List<Choice> choices = new List<Choice>();

    // Add a new choice to the list
    public void AddChoice(string npcName, int InteractionNumber, NPC_State playerAnswer)
    {
        choices.Add(new Choice
        {
            npcName = npcName,
            InteractionNumber = InteractionNumber,
            playerAnswer = playerAnswer
        });
    }

    // Retrieve a choice based on the question key
    public Choice GetChoice(int InteractionNumber)
    {
        return choices.Find(c => c.InteractionNumber == InteractionNumber);
    }
}
