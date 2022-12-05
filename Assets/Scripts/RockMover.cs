using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMover : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-1f, 1f) * speed, 1f), ForceMode2D.Impulse);
    }
}
