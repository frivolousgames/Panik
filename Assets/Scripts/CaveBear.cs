using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveBear : GroundEnemy
{
    AnimatorStateInfo animInfo;
    public GameObject sitCollider;
    public int borderHits;
    public int roars;
    public int totalRoars;

    bool thresholdReached;

    GameObject[] savedBorders;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        borderCol = GetComponent<BoxCollider2D>();
        groundCol = GetComponent<EdgeCollider2D>();
        //rbVelocity = new Vector2(speed, rb.velocity.y);
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
        borderHits = 0;
    }

    private void Start()
    {
        anim.SetTrigger("Sitting");
        rbVelocity = Vector2.zero;
        StartCoroutine("StandUpAndGrowl");
        borders = GameObject.FindGameObjectsWithTag("PlatformBorder");
        savedBorders = borders;
    }

    void Update()
    {
        if (dead != true)
        {
            borders = GameObject.FindGameObjectsWithTag("PlatformBorder");
            //Shoot();
            


        }
        SwitchColliders();
        SwitchCollidersBack();
        HealthThreshSettings();
        //Debug
        //Debug.Log("Roars " + totalRoars);
        BatTime();
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

    void RunMover()
    {
        anim.SetTrigger("Run");
        if(transform.localScale.x > 0)
        {
            rbVelocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rbVelocity = new Vector2(-speed, rb.velocity.y);
        }
        
    }

    IEnumerator StandUpAndGrowl()
    {
        yield return new WaitForSeconds(2.8f);
        anim.SetTrigger("Stand");
        StartCoroutine("Roar");
    }

    IEnumerator Roar()
    {
        yield return new WaitForSeconds(.5f);
        anim.SetTrigger("StandingRoar");
        StartCoroutine("Run");
    }

    IEnumerator Run()
    {
        yield return new WaitForSeconds(2f);
        RunMover();
    }

    
  
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (borders != null)
        {
            foreach (GameObject border in borders)
            {
                if (other.gameObject == border)
                {
                    rbVelocity = new Vector2(-transform.localScale.x * speed, rb.velocity.y);
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                    borderHits++;
                    //platformBorderHit = false;
                }
            }
        }
        if (other.gameObject == sitCollider)
        {
            anim.SetTrigger("Sit");
            rbVelocity = Vector2.zero;
        }
    }
    void SwitchColliders()
    {
        if(borderHits == 6)
        {
            if (savedBorders != null)
            {
                foreach (GameObject border in savedBorders)
                {
                    border.gameObject.SetActive(false);
                }
            }
            sitCollider.SetActive(true);
            borderHits = 0;
        }
        
    }
    void SwitchCollidersBack()
    {
        if(roars == 5)
        {
            anim.SetTrigger("Stand");
            RunMover();
            sitCollider.SetActive(false);
            roars = 0;
            StartCoroutine("ActivateColliders");
        }
    }

    IEnumerator ActivateColliders()
    {
        yield return new WaitForSeconds(1f);
        if (savedBorders != null)
        {
            foreach (GameObject border in savedBorders)
            {
                border.gameObject.SetActive(true);
            }
        }
    }

    public void AddRoars()
    {
        roars++;
        totalRoars++;
    }

    public void Bats()
    {

    }

    public void ThresholdReached()
    {
        thresholdReached = true;
    }

    void HealthThreshSettings()
    {
        if(thresholdReached == true)
        {
            speed += 2;
            thresholdReached = false;
            Debug.Log("T reached " + thresholdReached);
        }


    }
    void BatTime()
    {
        if(totalRoars > 10)
        {
            RoarObjects.isBatty = true;
        }
    }
}
