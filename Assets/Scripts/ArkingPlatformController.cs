using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkingPlatformController : PlatformMover
{
    public float arkSpeed;
    public float angle;
    

    private void Awake()
    {
        borders = GameObject.FindGameObjectsWithTag("MovingPlatformBorder");
        moving = true;
        angle = 0f;
    }
    private void Update()
    {
        SetDirection();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        foreach (GameObject border in borders)
        {
            if (other.gameObject == border)
            {
                moving = false;
                angle = 0;
                StartCoroutine("ChangeDirection");
            }
        }
    }

    public override void SetDirection()
    {
        if(moving == true)
        {
            angle += .01f * Time.deltaTime * arkSpeed;
            Mathf.Clamp(angle, 0, 1);

            if(flipped == false)
            {
                targetPosition = Vector2.Lerp(new Vector2(borderRight.transform.position.x, borderLeft.transform.position.y), borderRight.transform.position + borderOffset, angle);
            }
            else
            {
                targetPosition = Vector2.Lerp(new Vector2(borderRight.transform.position.x, borderLeft.transform.position.y), borderLeft.transform.position + borderOffset, angle);
            }
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        } 
    }
}
