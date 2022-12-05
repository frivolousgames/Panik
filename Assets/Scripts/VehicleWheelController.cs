using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VehicleWheelController : MonoBehaviour
{
    public GameObject vehicle;

    Rigidbody2D vehicleRb;
    public float speed;

    bool grounded;
    CircleCollider2D col;

    public LayerMask ground;

    private void Awake()
    {
        col = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        vehicleRb = vehicle.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Debug.Log(bothLanded);
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.IsTouchingLayers(col, ground);

        if(grounded == true)
        {
            transform.Rotate(0f, 0f, vehicleRb.velocity.x * speed);
        }
        else
        {
            transform.Rotate(0f, 0f, vehicleRb.velocity.x * speed * .7f);
        }
    }

    
}
