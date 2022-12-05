using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnBoost : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }
}
