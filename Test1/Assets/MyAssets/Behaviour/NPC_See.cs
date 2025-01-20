using UnityEngine;

public class NPC_See : MonoBehaviour
{
    [Header("Vision Settings")]
    public float detectionRange = 10f;
    public float fieldOfView = 45f;
    public LayerMask detectionMask;
    public Transform eyes;

    [Header("Target Tag")]
    public string targetTag = "Cube";

    public bool targetInSight;



    void Update()
    {
        targetInSight = CheckForTarget();
// Debug.Log(targetInSight);
    }

    private bool CheckForTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRange, detectionMask);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag(targetTag))
            {
                Vector3 directionToTarget = (hit.transform.position - eyes.position).normalized;
                float angleToTarget = Vector3.Angle(eyes.forward, directionToTarget);

                if (angleToTarget <= fieldOfView)
                {
                    if (Physics.Raycast(eyes.position, directionToTarget, out RaycastHit rayHit, detectionRange, detectionMask))
                    {
                        if (rayHit.collider == hit)
                        {
                            Debug.DrawLine(eyes.position, hit.transform.position, Color.green);
                            
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }
}
