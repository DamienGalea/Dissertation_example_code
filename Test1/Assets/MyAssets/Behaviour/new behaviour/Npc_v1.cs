using System;
using System.Net.NetworkInformation;
using Unity.Behavior;
using UnityEngine;

public class Npc_v1 : MonoBehaviour
{
    public enum NPCType
    {
        Gaurd,
        Civilian,
        Merchant
    }

    NPCType npcType;

    private Emotion_States_NPC currentState;
    public Player playerScript;

    public bool hasTalked;
    public bool isPlayerInRange;

    public BehaviorGraphAgent behaviourAgent;
    public BlackboardVariable<Emotion_States_NPC> bv_EmotionState;  //set something similar to the bool and see if varial.value == true works 
    public BlackboardVariable<Boolean> bv_hasTalked;
    public BlackboardVariable<Boolean> bv_playerIsInRange;



    private void Awake()
    {

        GameObject player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Player>();
        behaviourAgent = GetComponent<BehaviorGraphAgent>();

        currentState = Emotion_States_NPC.Sad;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerRange(isPlayerInRange);

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && hasTalked == false) 
        {
            
            hasTalked = true;
            

            SetEmotionInBehaviourGraph(currentState); //changing the enum in the graph
            Debug.Log("Talked");

            

        }
        else if (isPlayerInRange && hasTalked == true)
        {

            SetConverstaion(hasTalked); //changing the boolean

        }
        else if(isPlayerInRange && currentState == Emotion_States_NPC.Sad) //For sadness if the player is range and the npc is sad even if the conversation didn't happen yet the npc wont talk
        {
            hasTalked = true;
            SetEmotionInBehaviourGraph(currentState);
            SetConverstaion(hasTalked);
        }


    }

    public void SetEmotionInBehaviourGraph(Emotion_States_NPC npcState)
    {
        behaviourAgent.BlackboardReference.GetVariable("EmotionState", out bv_EmotionState);
        bv_EmotionState.Value = npcState;

    }

    public void SetConverstaion(bool _talked)
    {
        behaviourAgent.BlackboardReference.GetVariable("hasTalked", out bv_hasTalked);
        bv_hasTalked.Value = _talked;
    }

    public void PlayerRange(bool _playerIsInRange)
    {
       
        behaviourAgent.BlackboardReference.GetVariable("isPlayerInRange", out bv_playerIsInRange);
        bv_playerIsInRange.Value = _playerIsInRange;
    }


    


}
