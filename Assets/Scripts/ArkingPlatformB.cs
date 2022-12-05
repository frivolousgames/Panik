using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkingPlatformB : PlatformMover
{
    
    Vector2 arc;
    public float arkSpeed;
    public float angle;

    private void Awake()
    {
        borders = GameObject.FindGameObjectsWithTag("MovingPlatformBorder");
        moving = true;
    }
    private void Update()
    {
        SetDirection();
        //rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        foreach (GameObject border in borders)
        {
            if (other.gameObject == border)
            {
                moving = false;
                angle = 0;
                //Debug.Log("HIT");
                //velocity = Vector2.zero;
                StartCoroutine("ChangeDirection");
            }
        }
    }
    public override IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(waitTime);
        if (flipped == true)
        {
            flipped = false;
        }
        else
        {
            flipped = true;
        }
        moving = true;
    }

    public override void SetDirection()
    {
        if (moving == true)
        {
            angle += .1f * Time.deltaTime;
            if (flipped == false)
            {
                //direction = new Vector2(1f, angle * arkSpeed).normalized;
                //direction = Vector2.Lerp(Vector2.up, Vector2.left, angle * arkSpeed).normalized;
            }
            else
            {
                //direction = new Vector2(-1f, -angle * arkSpeed).normalized;
                //direction = Vector2.Lerp(-Vector2.left, -Vector2.up, angle * arkSpeed).normalized;
            }
            //velocity = direction * speed;
        }
    }
}
