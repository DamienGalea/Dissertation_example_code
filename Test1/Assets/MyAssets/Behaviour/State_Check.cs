using System;
using System.Net.NetworkInformation;
using Unity.Behavior;
using UnityEngine;

public class State_Check : MonoBehaviour
{
    
    public BehaviorGraphAgent behaviorAgent;
    public BlackboardVariable<NPC_State> blackboardVariable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    
    public void Initialize(GameObject NPC)
    {
        behaviorAgent = NPC.GetComponent<BehaviorGraphAgent>();
        
    }


    public bool StateCheck(NPC_State npcState)
    {
        behaviorAgent.BlackboardReference.GetVariable("NPC_State", out blackboardVariable);

        if (blackboardVariable.Value == npcState)
        {
            return true;
        }
        else
        {
            return false;
        }

    

    }

    public NPC_State CurrentState()
    {
        behaviorAgent.BlackboardReference.GetVariable("NPC_State", out blackboardVariable);
        var state = blackboardVariable.Value;
        Debug.Log("NPC is" + state);
        return state;

    }

    /*
     * private GameObject NPC_leader;
    public BehaviorGraphAgent behaviorAgent;
    public BlackboardVariable<NPC_State> blackboardVariable;

     * public void testing()
    {
        behaviorAgent.BlackboardReference.GetVariable("NPC_State", out blackboardVariable);
        Debug.Log(blackboardVariable.Value);
        if (blackboardVariable.Value == NPC_State.IDLE)
        {
            Debug.Log("Counsel");
        }
    }*/

}
