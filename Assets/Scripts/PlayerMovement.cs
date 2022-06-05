using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float playerMovementSpeed = 2f;
    bool isFacingRight =true;

    private bool isGrounded;
    
    private Rigidbody2D rb;
    Vector2 jumpForceDirection = new Vector2(0f, 1f);
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }



    void FixedUpdate()
    {
        
        HorizontalMovement();
        
    }

    void HorizontalMovement()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        rb.position += input.normalized * playerMovementSpeed * Time.deltaTime;
        if(input.x > 0 && isFacingRight == false)
        {
            Flip();
        }
        else if(input.x < 0 && isFacingRight == true)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    
    

    

}
