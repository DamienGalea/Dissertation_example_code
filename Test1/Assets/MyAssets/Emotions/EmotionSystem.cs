using UnityEngine;

public class EmotionSystem : MonoBehaviour
{
    /*public string npcId;

    // Store NPC's dominant emotion as an NPC_State
    public NPC_State CurrentEmotion { get; private set; } = NPC_State.Neutral;

    // Emotion levels (0–100)
    private int fear = 50;
    private int anger = 50;
    private int happiness = 50;
    private int confidence = 50;
    private int trust = 50;

    // Adjust emotions based on player's actions
    public void AdjustEmotion(NPC_State playerEmotion, int value)
    {
        switch (playerEmotion)
        {
            case NPC_State.ATTACK:
                anger = Mathf.Clamp(anger + value, 0, 100);
                confidence = Mathf.Clamp(confidence - value / 2, 0, 100);
                break;
            case NPC_State.HIT:
                happiness = Mathf.Clamp(happiness + value, 0, 100);
                trust = Mathf.Clamp(trust + value / 2, 0, 100);
                break;
            case NPC_State.IDLE:
                fear = Mathf.Clamp(fear + value, 0, 100);
                confidence = Mathf.Clamp(confidence - value, 0, 100);
                break;
            case NPC_State.Confident:
                confidence = Mathf.Clamp(confidence + value, 0, 100);
                anger = Mathf.Clamp(anger - value / 2, 0, 100);
                break;
            case NPC_State.Distrustful:
                trust = Mathf.Clamp(trust - value, 0, 100);
                break;
            case NPC_State.Sad:
                happiness = Mathf.Clamp(happiness - value, 0, 100);
                break;
        }

        UpdateDominantEmotion();
    }

    // Determine the dominant emotion based on the highest value
    private void UpdateDominantEmotion()
    {
        int maxEmotion = Mathf.Max(fear, anger, happiness, confidence, trust);

        if (maxEmotion == fear) CurrentEmotion = NPC_State.Fearful;
        else if (maxEmotion == anger) CurrentEmotion = NPC_State.Angry;
        else if (maxEmotion == happiness) CurrentEmotion = NPC_State.Happy;
        else if (maxEmotion == confidence) CurrentEmotion = NPC_State.Confident;
        else if (maxEmotion == trust) CurrentEmotion = NPC_State.Neutral; // Trust affects neutrality
        else CurrentEmotion = NPC_State.Neutral;
    }

    // NPC reaction based on dominant emotion
    public string GetNPCReaction()
    {
        switch (CurrentEmotion)
        {
            case NPC_State.Fearful: return "The NPC looks scared and takes a step back.";
            case NPC_State.Angry: return "The NPC is furious and refuses to talk.";
            case NPC_State.Happy: return "The NPC smiles warmly at you.";
            case NPC_State.Confident: return "The NPC speaks with determination.";
            case NPC_State.Distrustful: return "The NPC looks at you with suspicion.";
            case NPC_State.Sad: return "The NPC seems down and avoids eye contact.";
            default: return "The NPC remains neutral.";
        }
    }*/
}
