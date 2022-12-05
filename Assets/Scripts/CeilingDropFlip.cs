using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingDropFlip : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D col;
    GameObject spider;
    GameObject player;

    private void Awake()
    {
        spider = transform.parent.gameObject;
        rb = spider.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("PhysicalCollider");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            if(spider.transform.localScale.y < 0)
            {
                rb.gravityScale = -rb.gravityScale;
                spider.transform.localScale = new Vector2(spider.transform.localScale.x, -spider.transform.localScale.y);
            }
        }
    }
}
