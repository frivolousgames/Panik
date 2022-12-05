using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceController : MonoBehaviour
{
    Rigidbody2D rb;
    float speed;

    public Animator anim;
    public static bool paused;
    public static string winner;
    
    public GameObject finishLine;

    Vector2 pausedScale;

    private void Awake()
    {
        winner = null;
        paused = true;
        rb = GetComponent<Rigidbody2D>();
        speed = 0;
        StartCoroutine("SpeedAdjust");
    }


    private void FixedUpdate()
    {
        if (GameController.freezeAll != true)
        {
            if (paused == false)
            {
                rb.velocity = Vector2.right * speed;
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
            }
        }
        else
        {
            anim.speed = 0;
        }

        
        Debug.Log(winner + " winner ");
    }
    IEnumerator SpeedAdjust()
    {
        while(paused == true)
        {
            speed = 0;
            yield return null;
        }
        while(paused != true)
        {
            speed = Random.Range(0.6f, 01.2f);
            yield return new WaitForSeconds(.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == finishLine)
        {
            if (paused == false)
            {
                if(winner == null)
                {
                    winner = gameObject.name;
                    pausedScale = transform.localScale;
                    paused = true;
                    
                }               
            }
        }
    }
}
