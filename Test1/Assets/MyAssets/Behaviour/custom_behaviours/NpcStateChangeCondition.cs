using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "NPCStateChange", story: "[NPC] [state] changed to [what]", category: "Conditions", id: "d1bad45838d3b5f018f7f2f9eecfcf3c")]
public partial class NpcStateChangeCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> NPC;
    [SerializeReference] public BlackboardVariable<State_Check> State;
    [SerializeReference] public BlackboardVariable<NPC_State> What;

    public override bool IsTrue()
    {
        return State.Value.StateCheck(What.Value);
    }

    public override void OnStart()
    {
        State.Value.Initialize(NPC);
    }

    public override void OnEnd()
    {
    }
}
