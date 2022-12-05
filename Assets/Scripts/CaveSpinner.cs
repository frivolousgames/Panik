using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveSpinner : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public float power;

    private void Awake()
    {
        rb = GetComponent <Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
        //power = Mathf.Lerp(power, 0, Time.deltaTime * speed);
        
        rb.rotation = power;
    }

    private void Update()
    {
        power = Mathf.PingPong(Time.time * speed, 360f);
    }


}
