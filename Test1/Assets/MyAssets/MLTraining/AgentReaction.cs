using UnityEngine;
using Unity.MLAgents;
using System.Net.NetworkInformation;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


public class AgentReaction : Agent
{
    public Transform rayOrigin;  // Set this to the agent's eyes or a camera point
    public float rayLength = 10f;
    public NPC NPCscript;

    public States_NPC NPCState;
    private States_NPC playerDetectedState;
    private bool sawNPC = false;

    public override void OnEpisodeBegin()
    {
        sawNPC = false; // Reset detection
        
        
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Check if NPC is detected via raycast
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, rayLength))
        {
            Player player = hit.collider.GetComponent<Player>();
            if (player != null)
            {
                playerDetectedState = player.state;
                sawNPC = true;
            }
        }
        else
        {
            sawNPC = false;
        }

        // Observe the NPC's state if seen
        sensor.AddObservation(sawNPC ? (int)playerDetectedState : -1);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        if (!sawNPC)
        {
            SetReward(-0.5f); // Penalize if NPC not found
            return;
        }

        int action = actionBuffers.DiscreteActions[0];

        if (NPCState == States_NPC.TALK && action == 1)
        {
            
            NPCscript.Talk();
            SetReward(1.0f);
        }
        else if (NPCState == States_NPC.HIT && action == 0)
        {
            NPCscript.Hit();
            SetReward(1.0f);
        }
        else
        {
           
            SetReward(-1.0f);
        }

        // End episode after an action is taken
        EndEpisode();
    }

   

}
