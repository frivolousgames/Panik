using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatformMover : PlatformMover
{
    private void Awake()
    {
        SetDirection();
        borders = GameObject.FindGameObjectsWithTag("MovingPlatformBorder");
        
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        foreach (GameObject border in borders)
        {
            if (other.gameObject == border)
            {

                StartCoroutine("ChangeDirection");
            }
        }
    }
    
    
}
