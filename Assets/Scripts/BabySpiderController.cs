using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySpiderController : GroundEnemy

{
    float jumpWaitTime;
    bool isJumping;
    BoxCollider2D playerFeet;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        borderCol = GetComponent<BoxCollider2D>();
        groundCol = GetComponent<EdgeCollider2D>();
        playerFeet = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        //rbVelocity = new Vector2(speed, rb.velocity.y);
    }

    private void Update()
    {
        if (dead != true)
        {
            borders = GameObject.FindGameObjectsWithTag("PlatformBorder");
            JumpRoutine();

            
            
            /*if (GameController.freezeAll != true)
            {
                Shoot();

            }*/
        }
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("Jumping", isJumping);
        anim.SetBool("InAir", inAir);
        jumpWaitTime = Random.Range(.9f, 1.1f);
    }
    private void FixedUpdate()
    {
        if (dead != true)
        {
            isGrounded = Physics2D.IsTouchingLayers(borderCol, groundLayer);
            //platformBorderHit = Physics2D.IsTouchingLayers(borderCol, platformBorder);
            if (inAir == false)
            {
                WalkRoutine();
                Grounded();
            }
            Jumping();
            rb.velocity = rbVelocity;  
            WalkingDirection();
            
            //TurnAround();

        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        Debug.Log(rbVelocity);
    }

    /*public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if(other == playerFeet)
        {
            Destroy(gameObject);
        }
    }*/

    void JumpRoutine()
    {
        if(transform.localScale.y > 0)
        {
            if(isGrounded == true)
            {
                if(isJumping == false)
                {
                    Debug.Log("JUMP");
                    isJumping = true;
                    StartCoroutine("JumpWait");
                }
                
            }
        }
    }

    IEnumerator JumpWait()
    {
        yield return new WaitForSeconds(jumpWaitTime);
        //rbVelocity = new Vector2(rbVelocity.x, rb.velocity.y);
        inAir = true;
        anim.SetTrigger("Jump");
        isJumping = false;
        yield return new WaitForSeconds(.2f);
        inAir = false;
    }

    void Jumping()
    {
        if (inAir == true)
        {
            rbVelocity = new Vector2(rb.transform.localScale.x * speed, rb.velocity.y);
        }
    }

    void Grounded()
    {
        if (isGrounded == false)
        {
            rbVelocity = new Vector2(rbVelocity.x, rb.velocity.y);
        }
    }


}
