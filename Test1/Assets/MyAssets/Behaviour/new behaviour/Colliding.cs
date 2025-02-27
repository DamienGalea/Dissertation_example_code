using System.Security.Cryptography;
using UnityEngine;

public class Colliding : MonoBehaviour
{
    private Npc_v1 _Npc_v1;

    private void Awake()
    {
        _Npc_v1 = GetComponentInParent<Npc_v1>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _Npc_v1.isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _Npc_v1.isPlayerInRange = false;
        }
    }
}
