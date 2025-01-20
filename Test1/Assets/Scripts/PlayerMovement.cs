using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public Animator animator; // Reference to the Animator

    private void Start()
    {
       rb = GetComponent<Rigidbody>();
       rb.freezeRotation = true;
    }

    private void Update()
    {
        
        MyInput();



        if (Input.GetKey(KeyCode.Space)) // Replace Space with your desired key
        {
            animator.SetBool("isPunch", true);
            Debug.Log("Hit");
        }
        else
        {
            animator.SetBool("isPunch", false);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
