using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "If bool is false", story: "Is [Boolean] false", category: "Conditions", id: "b77eba5cb00a1989bd1a22093b8f625a")]
public partial class IfBoolIsFalseCondition : Condition
{
    [SerializeReference] public BlackboardVariable<bool> Boolean;

    public override bool IsTrue()
    {
        return Boolean != null && !Boolean.Value;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
