using System;
using System.Net.NetworkInformation;
using Unity.Behavior;
using UnityEngine;

public class State_Check : MonoBehaviour
{
    
    public BehaviorGraphAgent behaviorAgent;
    public BlackboardVariable<NPC_State> blackboardVariable;

    //Create myself

    public void Start()
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
        behaviorAgent.BlackboardReference.GetVariable("NPCStateVariable", out blackboardVariable); // "Variable" must be the name of the variable in the garph else a null error appears 
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
