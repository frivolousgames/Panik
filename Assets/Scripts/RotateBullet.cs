using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBullet : MonoBehaviour
{
    Rigidbody2D rb;
    bool left;
    public float speed;
    Vector3 rotationAngle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(transform.parent.localScale.x > 0)
        {
            left = false;
        }
        else
        {
            left = true;

        }
    }

    private void FixedUpdate()
    {
        if(left == true)
        {
            rb.rotation -= speed;
        }
        else
        {
            rb.rotation += speed;
        }
        //Debug.Log("rotation: " + rotationAngle);
    }
}
