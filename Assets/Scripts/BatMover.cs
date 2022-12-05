using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMover : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 rbVelocity;
    bool isFlapping;
    public float power;
    public float boostWait;
    GameObject player;
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine("StopFlapping");
        
        player = GameObject.FindGameObjectWithTag("Player");
        isFlapping = true;
    }

    private void Update()
    {
        if (isFlapping == true)
        {
            StartCoroutine("StopFlapping");
        }
      
            
    }

    private void FixedUpdate()
    {
        if(player != null)
        {
            rb.MovePosition(Vector2.Lerp(transform.position, player.transform.position, speed * Time.fixedDeltaTime));
        }
        if(isFlapping == true)
        {
            rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
        }
        
        

    }

    IEnumerator StopFlapping()
    {
        yield return new WaitForSeconds(.01f);
        isFlapping = false;
        StartCoroutine("StartFlapping");
    }
    IEnumerator StartFlapping()
    {
        yield return new WaitForSeconds(boostWait);
        isFlapping = true;
        //StartCoroutine("StopFlapping");
    }
}
