using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeMover : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 velocity;
    public float speed;
    public float minHeight;
    public float maxHeight;
    public float oSpeed;
    float heightSpeed;
    float min = 0;
    public GameObject health;
    bool dead;
    public float upForce;
    public UnityEvent die;

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        oSpeed = .7f;
        dead = false;

    }

    private void Update()
    {
        if(dead != true)
        {
            velocity = new Vector2(speed, Mathf.SmoothStep(minHeight, maxHeight, heightSpeed));
            heightSpeed = Mathf.PingPong(Time.time * oSpeed, 1);
            min += Time.deltaTime;
            rb.velocity = velocity;
        }
        
        /*if (health.GetComponent<EnemyHealth>().isDead == true)
        {
            die.Invoke();
            dead = true;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 4;
            rb.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
        }*/
    }

    public void Dead()
    {
        die.Invoke();
        dead = true;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 4;
        rb.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
    }
}
