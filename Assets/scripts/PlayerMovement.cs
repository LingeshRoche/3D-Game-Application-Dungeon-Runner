using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float jumpstrength = 5f;
    public float MovementSpeed = 6f;
    Rigidbody rb;
    public Transform groundCheck;
    public LayerMask ground;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * MovementSpeed, rb.velocity.y, verticalInput * MovementSpeed);

       
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
           
            animator.SetBool("isJump", true);
            Jump();
            
        }
        else
        {
            animator.SetBool("isJump", false);
        }

        if (rb.velocity.x != 0f || rb.velocity.z != 0f)
        {
            animator.SetBool("isMoving", true);
           
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        if (horizontalInput < 0)
        {
            animator.SetBool("isLeft", true); // Moving left
        }
        else
        {
            animator.SetBool("isLeft", false);
        }
        if (horizontalInput > 0)
        {
            animator.SetBool("isRight", true); // Moving right
        }
        else
        {
            animator.SetBool("isRight", false); // Not moving horizontally
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetBool("isMagic", true);
        }
    else{
            animator.SetBool("isMagic", false);
        }

    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jumpstrength, rb.velocity.z);
    }

     bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f , ground);
    }
}