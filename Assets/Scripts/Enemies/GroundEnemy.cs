using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundEnemy : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected BoxCollider2D borderCol;
    protected EdgeCollider2D groundCol;

    //Movement
    public float speed;
    protected Vector2 rbVelocity;
    protected bool isGrounded;
    protected bool movingRight;
    protected bool movingLeft;
    public LayerMask groundLayer;
    protected bool platformBorderHit;
    //public LayerMask platformBorder;
    protected Vector2 lastVelocity;
    protected GameObject[] borders;

    //Jump
    public float jumpForce;
    protected bool inAir;

    //Shoot
    public Transform shotSpawn;
    public GameObject bullet;
    public float shotWaitTime;
    protected bool justShot;
    public float shootAnimTime;
    public float shootAnimOutTime;
    public bool chill;

    //Animation
    public Animator anim;

    //Die

    //public 

    //public float dieForce;
    public GameObject hitCollider;
    public float dieUpForce;
    protected bool dead;
    protected bool inLimbo;

    //JUMP
    virtual public void Jump()
    {
        if (isGrounded != false)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    //WALK
    virtual public void WalkRoutine()
    {
        if(isGrounded == true)
        {
            if(transform.localScale.x < 0)
            {
                rbVelocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                rbVelocity = new Vector2(speed, rb.velocity.y);
            }
        }
    }

    virtual public void WalkingDirection()
    {
        if(inLimbo != true)
        {
            if (rb.velocity.x > 0)
            {
                movingRight = true;
                movingLeft = false;
            }
            else
            {
                movingLeft = true;
                movingRight = false;
            }
        }
        
    }

    /*virtual public void TurnAround()
    {
        if (platformBorderHit == true)
        {
            rbVelocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            platformBorderHit = false;
        }
    }*/

    virtual public void OnTriggerEnter2D(Collider2D other)
    {
        if(borders != null)
        {
            foreach (GameObject border in borders)
            {
                if (other.gameObject == border)
                {
                    Debug.Log("HIT");
                    rbVelocity = new Vector2(-transform.localScale.x * speed, rb.velocity.y);
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                    //platformBorderHit = false;
                }
            }
        }
    }

    //SHOOT
    virtual public void Shoot()
    {
        if(inLimbo != true || GameController.freezeAll != true)
        {
            if (justShot == false)
            {

                justShot = true;
                StartCoroutine("ShotWait");
            }
        }
        
    }
    IEnumerator ShotWait()
    {
        yield return new WaitForSeconds(shotWaitTime);
        lastVelocity = rbVelocity;
        rbVelocity = new Vector2(0, rb.velocity.y);
        anim.SetTrigger("Shoot");
        chill = false;
        StartCoroutine("WaitForAnimator");
    }
    IEnumerator WaitForAnimator()
    {
        yield return new WaitForSeconds(shootAnimTime);
        justShot = false;
        if(GameController.freezeAll != true)
        {
            Instantiate(bullet, shotSpawn.position, Quaternion.identity, transform);
        }
        
        StartCoroutine("WaitForAnimatorOut");

    }
    IEnumerator WaitForAnimatorOut()
    {
        yield return new WaitForSeconds(shootAnimOutTime);
        chill = true;
        rbVelocity = lastVelocity;
    }
    
    //DEAD
    
    virtual public void Killed()
    {
            dead = true;
            anim.SetTrigger("Die");
            //rb.velocity = Vector2.down * dieForce;
            rb.AddForce(Vector2.up * dieUpForce, ForceMode2D.Impulse);
            groundCol.isTrigger = true;
            Destroy(borderCol);
            inLimbo = true;
    }
    
}
