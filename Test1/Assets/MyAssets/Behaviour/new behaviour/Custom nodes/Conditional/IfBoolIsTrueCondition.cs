using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "If bool is true", story: "Is [Bool] True", category: "Conditions", id: "1cf57d3ec973afa5968852107bca5a5b")]
public partial class IfBoolIsTrueCondition : Condition
{
    [SerializeReference] public BlackboardVariable<bool> Bool;

    public override bool IsTrue()
    {
        return Bool != null && Bool.Value;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
