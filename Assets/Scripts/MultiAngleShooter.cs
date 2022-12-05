using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiAngleShooter : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 velocity;
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = transform.position * speed;
    }

    private void Start()
    {
        rb.AddForce(transform.right * transform.parent.localScale.x * speed);
        StartCoroutine("DetachWait");
    }
    IEnumerator DetachWait()
    {
        yield return new WaitForSeconds(.01f);
        transform.parent = null;
    }
}
