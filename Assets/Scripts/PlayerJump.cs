using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.2f;
    public bool isGrounded;


    [SerializeField] float jumpForce = 2f;
    [SerializeField] float jumpTime = 3f;
    float jumpTimeCounter;
    bool isJumping;
    float jumpModifer;

    protected Rigidbody2D rb;

    public event Action GravityWhenGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        GroundedCheck();
    }

    

    void FixedUpdate()
    {
        JumpMechanics();
        InvertedJump();
        GroundedGravitySwitch();
    }

    void GroundedGravitySwitch()
    {
        if (isGrounded == true)
        {
            if (GravityWhenGrounded != null)
            {
                GravityWhenGrounded();
            }
        }
    }

    void JumpMechanics()
    {

        if (Input.GetButton("Jump"))
        {
            if (isGrounded == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, InvertedJump());
                isJumping = true;
            }
        }
        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, InvertedJump());
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            isJumping = false;
        }
    }

    public void GroundedCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (isGrounded == true)
        {
            jumpTimeCounter = jumpTime;
        }
    }
    float InvertedJump()
    {
        if (rb.gravityScale < 0)
        {
            jumpModifer = -jumpForce;
        }
        else if (rb.gravityScale > 0)
        {
            jumpModifer = jumpForce;
        }
        return jumpModifer;
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    }
}
