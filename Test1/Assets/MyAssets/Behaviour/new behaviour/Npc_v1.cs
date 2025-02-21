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



    private void Awake()
    {

        GameObject player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Player>();
        behaviourAgent = GetComponent<BehaviorGraphAgent>();

        // Behaviour variables being set:
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && hasTalked == false) //&& bv_hasTalked.Value == false
        {
            hasTalked = true;
            currentState = Emotion_States_NPC.Afraid;

            SetEmotionInBehaviourGraph(currentState); //changing the enum in the graph

        }
        else if (isPlayerInRange && hasTalked == true)
        {

            SetConverstaion(hasTalked); //changing the boolean

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


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }


}
