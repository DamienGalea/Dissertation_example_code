using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void Talk()
    {
        animator.SetBool("A1", true);
        animator.SetBool("A2", false);
    }

    public void Hit()
    {
        animator.SetBool("A2", true);
        animator.SetBool("A1", false);
    }
}
