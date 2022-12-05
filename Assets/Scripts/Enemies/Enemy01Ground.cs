using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Ground : GroundEnemy
{
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        borderCol = GetComponent<BoxCollider2D>();
        groundCol = GetComponent<EdgeCollider2D>();
        rbVelocity = new Vector2(speed, rb.velocity.y);
    }
    void Start()
    {
        
    }
    
    void Update()
    {
        if (dead != true)
        {
            borders = GameObject.FindGameObjectsWithTag("PlatformBorder");
            if(GameController.freezeAll != true)
            {
                Shoot();

            }



        }
        //Debug
        //Debug.Log("Velocity " + rb.velocity.x);
    }

    private void FixedUpdate()
    {
        if (dead != true)
        {
            isGrounded = Physics2D.IsTouchingLayers(borderCol, groundLayer);
            //platformBorderHit = Physics2D.IsTouchingLayers(borderCol, platformBorder);
            rb.velocity = rbVelocity;
            WalkingDirection();
            //TurnAround();
            
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        //Debug.Log(rb.velocity);
    }

    /*public override void WalkRoutine()
    {
        rb.velocity = Vector2.right * speed;
        rb.velocity = Vector2.left * speed;
        Jump();
        Shoot();
    }*/
    /*public override void TurnAround()
    {
        
        if (platformBorderHit == true)
        {
            rbVelocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            platformBorderHit = false;
        }
    }*/

    
}
