using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelExplodeRoll : MonoBehaviour
{
    public GameObject parent;
    Rigidbody2D rb;
    public float speed;
    public float power;

    private void Awake()
    {
        rb = parent.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.AddForce(new Vector2(1f * power, 1f * power), ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, rb.velocity.x * speed);
    }

}
