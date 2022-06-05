using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    PlayerJump playerJump;

    Rigidbody2D rb2d;
    bool invertedGravity = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerJump = FindObjectOfType<PlayerJump>();
        playerJump.GravityWhenGrounded += GravityChange;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void GravityChange()
    {
        if (Input.GetButton("GravitySwitch") && invertedGravity == false)
        {
            rb2d.gravityScale = rb2d.gravityScale * -1;
            SpriteFlip();
        }
        else if (Input.GetButton("GravitySwitch") && invertedGravity == true)
        {
            rb2d.gravityScale = rb2d.gravityScale * -1;
            SpriteFlip();
        }
    }

    void SpriteFlip()
    {
        invertedGravity = !invertedGravity;
        Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;
    }
    
}
