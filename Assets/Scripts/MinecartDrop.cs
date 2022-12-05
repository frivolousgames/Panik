using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartDrop : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform target;
    public GameObject triggerSpot;

    public float speed;

    public GameObject gold;

    public float waitTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine("FallWait");
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == triggerSpot)
        {
            Instantiate(gold, transform.position, Quaternion.identity, null);
            rb.velocity = Vector2.zero;
        }
    }

    IEnumerator FallWait()
    {
        yield return new WaitForSeconds(waitTime);
        rb.velocity = Vector2.down * speed;
    }
}
