using System.Data;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator animator;
    public States_NPC currentState;


    public void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    void Start()
    {
        InvokeRepeating(nameof(UpdateState), 0f, 5f); // Updates state every 5 seconds
    }

    void Update()
    {
        //UpdateAnimation();
    }

    void UpdateState()
    {
        int enumLength = States_NPC.GetValues(typeof(States_NPC)).Length;
        int randomIndex = UnityEngine.Random.Range(0, enumLength);
        currentState = (States_NPC)randomIndex;
    }

    /*void UpdateAnimation()
    {
        if (currentState == States_NPC.HIT)
        {
            animator.SetBool("A1", false);
            animator.SetBool("A2", true);
        }
        else if (currentState == States_NPC.TALK)
        {
            animator.SetBool("A1", true);
            animator.SetBool("A2", false);
        }
        else
        {
            animator.SetBool("A1", false);
            animator.SetBool("A2", false); // Default to Idle
        }
    }*/

     public void Talk()
    {
        animator.SetBool("A1", true);
        animator.SetBool("A2", false);
    }

    public void Hit()
    {
        animator.SetBool("A1", false);
        animator.SetBool("A2", true);
    }

    void idle()
    {
        animator.SetBool("A1", false);
        animator.SetBool("A2", false); // Default to Idle
    }

}
