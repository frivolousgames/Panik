using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    Vector2 direction;
    Vector2 rbVelocity;

    private void Awake()
    {
         
        rb = GetComponent<Rigidbody2D>();

        direction = Vector2.zero;
        //rbVelocity = Vector2.zero;
        if (transform.parent != null)
        {
            rb.velocity = new Vector2(transform.parent.localScale.x * speed, rb.velocity.y);
            direction = new Vector2(transform.parent.localScale.x, transform.localScale.y);
        }
        //Debug.Log(transform.parent.localScale.x);

    }

    private void Start()
    {
        StartCoroutine("DetachWait");

    }

    private void Update()
    {
        if (GameController.freezeAll != true)
        {
            rb.simulated = true;
        }
        else
        {
            rb.simulated = false;
        }
            //Debug.Log(transform.localScale.x);

            transform.localScale = direction;
    }
    private void FixedUpdate()
    {
        
        
    }
    IEnumerator DetachWait()
    {
        yield return new WaitForSeconds(.01f);
        transform.parent = null;
    }

}
