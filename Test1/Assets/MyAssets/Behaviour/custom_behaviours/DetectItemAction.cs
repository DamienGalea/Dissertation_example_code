using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DetectItem", story: "NPC has [seen] the Item", category: "Action", id: "6e16972a08514c31cac05c703451c20f")]
public partial class DetectItemAction : Action
{
    [SerializeReference] public BlackboardVariable<NPC_See> Seen;
    protected override Status OnUpdate()
    {
        
        Debug.Log(Seen.Value.targetInSight);
        return Seen.Value.targetInSight == true ? Status.Failure : Status.Success;
    }

    
}

