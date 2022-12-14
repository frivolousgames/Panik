using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeShooter : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D col;
    public LayerMask groundLayer;
    bool hitGround;
    
    //public float dTime;
    public float throwPower;
    public float upForce;
    Vector2 direction;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        direction = Vector2.zero;
        if (transform.parent != null)
        {
            rb.AddForce(new Vector2(transform.parent.localScale.x * throwPower, upForce), ForceMode2D.Impulse);
            direction = new Vector2(transform.parent.localScale.x, transform.localScale.y);
        }
    }
    private void Start()
    {
        StartCoroutine("DetachWait");
    
    }

    private void Update()
    {
        transform.localScale = direction;
        hitGround = Physics2D.IsTouchingLayers(col, groundLayer);

        if (hitGround == true)
        {
            rb.velocity = Vector2.zero;
        }
    }
    IEnumerator DetachWait()
    {
        yield return new WaitForSeconds(.01f);
        transform.parent = null;
    }

}
