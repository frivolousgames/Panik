using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public float speed;
    protected Vector2 targetPosition;
    protected GameObject[] borders;
    public float waitTime;

    protected bool moving;
    protected bool flipped;

    public Transform borderLeft;
    public Transform borderRight;

    public Vector3 borderOffset; 

    public virtual IEnumerator ChangeDirection()
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

    public virtual void SetDirection()
    {
        if (flipped == false)
        {
            targetPosition = borderRight.transform.position + borderOffset;
        }
        else
        {
            targetPosition = borderLeft.transform.position + borderOffset;
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
    }
}
