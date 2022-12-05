using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerPosition : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPos;
    HingeJoint2D hinge;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        startPos = transform.position;
    }
    private void Update()
    {
        if(WheelController.spinOver != false)
        {
            rb.angularVelocity = 0f;
        }
        
    }

    private void FixedUpdate()
    {
        transform.position = startPos;
    }
}
