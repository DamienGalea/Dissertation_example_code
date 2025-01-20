using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/OnStateChanged")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "OnStateChanged", message: "NPC state has change to [current_state]", category: "Events", id: "02e18208d69eaebdabe097c0152a676c")]
public partial class OnStateChanged : EventChannelBase
{
    public delegate void OnStateChangedEventHandler(NPC_State current_state);
    public event OnStateChangedEventHandler Event; 

    public void SendEventMessage(NPC_State current_state)
    {
        Event?.Invoke(current_state);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<NPC_State> current_stateBlackboardVariable = messageData[0] as BlackboardVariable<NPC_State>;
        var current_state = current_stateBlackboardVariable != null ? current_stateBlackboardVariable.Value : default(NPC_State);

        Event?.Invoke(current_state);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        OnStateChangedEventHandler del = (current_state) =>
        {
            BlackboardVariable<NPC_State> var0 = vars[0] as BlackboardVariable<NPC_State>;
            if(var0 != null)
                var0.Value = current_state;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as OnStateChangedEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as OnStateChangedEventHandler;
    }
}

