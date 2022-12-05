using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerWalkerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    public Animator anim;
    bool paused = false;

    GameObject player;

    Vector2 pausedScale;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void FixedUpdate()
    {
        if(GameController.freezeAll != true)
        {
            if (paused == false)
            {
                if (transform.localScale.x > 0)
                {
                    rb.velocity = Vector2.right * speed;
                }
                else
                {
                    rb.velocity = -Vector2.right * speed;
                }
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void Update()
    {
        if (GameController.freezeAll != true)
        {
            if (paused == false)
            {
                anim.speed = 1;
            }
            else
            {
                anim.speed = 0;
                if (player.transform.position.x < transform.position.x)
                {
                    transform.localScale = new Vector2(-1, transform.localScale.y);
                }
                else
                {
                    transform.localScale = new Vector2(1, transform.localScale.y);
                }
            }
        }
        else
        {
            anim.speed = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (GameObject.FindGameObjectWithTag("EnterHouseButton") == null)
        {
            
            if (other.gameObject == player)
            {
                if (paused == false)
                {
                    pausedScale = transform.localScale;
                    paused = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (paused == true)
            {
                paused = false;
                transform.localScale = pausedScale;
            }
        }     
    }
}
