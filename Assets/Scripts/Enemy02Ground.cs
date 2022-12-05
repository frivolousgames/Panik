using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02Ground : GroundEnemy
{
    public bool shooting;
    public bool walking;
    public GameObject attackCollider;

    GameObject player;
    CapsuleCollider2D playerCollider;
    public float rayBuffer;
    LayerMask playerLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        borderCol = GetComponent<BoxCollider2D>();
        groundCol = GetComponent<EdgeCollider2D>();
        rbVelocity = new Vector2(speed, rb.velocity.y);
        walking = true;
        
    }
    void Start()
    {
        playerLayer = LayerMask.GetMask("Player");
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = GameObject.FindGameObjectWithTag("PlayerHitCollider").GetComponent<CapsuleCollider2D>();

    }
    void Update()
    {
        if (dead != true)
        {
            borders = GameObject.FindGameObjectsWithTag("PlatformBorder");
        }
        anim.SetBool("Walking", walking);
        anim.SetBool("Shooting", shooting);
        WalkingDirection();

    }

    private void FixedUpdate()
    {
        if (dead != true)
        {
            isGrounded = Physics2D.IsTouchingLayers(borderCol, groundLayer);
            rb.velocity = rbVelocity;
            WalkingDirection();
            WalkRoutine();
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        AttackRaycast();

        void AttackRaycast()
        {
            RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + rayBuffer, transform.position.y), Vector2.right, 10, playerLayer);
            RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - rayBuffer, transform.position.y), -Vector2.right, 10, playerLayer);

            Debug.DrawRay(new Vector2(transform.position.x + rayBuffer, transform.position.y), Vector2.right * 10, Color.blue);
            Debug.DrawRay(new Vector2(transform.position.x - rayBuffer, transform.position.y), -Vector2.right * 10, Color.red);
            //if(hitLeft.collider != null)
            if (hitRight.collider == playerCollider || hitLeft.collider == playerCollider)
            {
                if (shooting == false)
                {
                    shooting = true;
                    Debug.Log("HIT");
                    if (player.transform.position.x < transform.position.x)
                    {
                        transform.localScale = new Vector2(-1, transform.localScale.y);
                        if (movingLeft != true)
                        {
                            rbVelocity = new Vector2(transform.localScale.x * speed, rb.velocity.y);
                        }

                    }
                    else
                    {
                        transform.localScale = new Vector2(1, transform.localScale.y);
                        if (movingLeft == true)
                        {
                            rbVelocity = new Vector2(transform.localScale.x * speed, rb.velocity.y);
                        }
                    }
                }

            }
            else
            {
                shooting = false;
            }
        }
    }
}
