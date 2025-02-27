using UnityEngine;
using Unity.MLAgents;
using System.Net.NetworkInformation;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.AI;
using System.Collections;


public class AgentReaction : Agent
{
    private NavMeshAgent navMeshAgent;
    public Transform[] randomLocations; // Possible escape points
    private States_NPC currentEmotion = States_NPC.None; // Default state

    private Vector3 lastPosition;
    private float stillnessThreshold = 0.1f; // Minimum movement required
    private float stillnessTimer = 0f; // Timer to track inactivity
    private float maxStillnessTime = 3.0f; // If the agent doesn't move for 3 seconds, end the episode

    public override void Initialize()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void OnEpisodeBegin()
    {
        navMeshAgent.isStopped = false;
        lastPosition = transform.position;
        stillnessTimer = 0f;

        if (currentEmotion == States_NPC.Scared)
        {
            MoveToRandomLocation();
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation((int)currentEmotion); // 1 observation
        sensor.AddObservation(transform.position);  // 3 observations (X, Y, Z)
        sensor.AddObservation(navMeshAgent.velocity.magnitude); // 1 observation (Speed)

        // Total: 1 + 3 + 1 = **5 observations**
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (currentEmotion == States_NPC.Scared)
        {
            // Check if the agent has moved significantly
            if (Vector3.Distance(transform.position, lastPosition) < stillnessThreshold)
            {
                stillnessTimer += Time.deltaTime;
            }
            else
            {
                stillnessTimer = 0f; // Reset timer if the agent moves
            }

            // Punish stillness if the agent fails to move within maxStillnessTime
            if (stillnessTimer >= maxStillnessTime)
            {
                AddReward(-1.0f); // Penalize for not moving
                EndEpisode(); // End the episode
            }

            // Reward if the agent reaches the random location
            if (navMeshAgent.remainingDistance < 1.0f)
            {
                AddReward(1.0f); // Reward for reaching the location
                EndEpisode(); // End the episode
            }
        }

        lastPosition = transform.position;
    }

    private void MoveToRandomLocation()
    {
        if (randomLocations.Length == 0) return;
        Transform randomPoint = randomLocations[Random.Range(0, randomLocations.Length)];
        navMeshAgent.SetDestination(randomPoint.position);
    }

    public void SetEmotion(States_NPC newEmotion)
    {
        currentEmotion = newEmotion;
        OnEpisodeBegin(); // Restart episode when emotion is changed
    }



}
