using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "StateAnimation", story: "[NPC] [state] changed: [Animation] updated", category: "Action", id: "e2de811c8aba1c4527d9b5790314c624")]
public partial class StateAnimationAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> NPC;
    [SerializeReference] public BlackboardVariable<Animator> Animation;
    [SerializeReference] public BlackboardVariable<State_Check> state;

    NPC_State current_state;

    protected override Status OnStart()
    {
       

        //Debug.Log("StateAnimationAction: Initializing State_Check for NPC: " + NPC.Value.name);

        state.Value.Initialize(NPC);

        current_state = state.Value.CurrentState();
        Debug.Log("StateAnimationAction: Current state retrieved: " + current_state);

        return Status.Success;
    }


    public void FixedUpdate()
    {

    }
    protected override Status OnUpdate()
    {
        if (current_state == NPC_State.DEATH)
        {
            Debug.Log("Maoer");
            Animation.Value.SetTrigger("Death");
        }
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

