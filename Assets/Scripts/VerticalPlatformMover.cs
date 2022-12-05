using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatformMover : PlatformMover
{
    private void Awake()
    {
        borders = GameObject.FindGameObjectsWithTag("MovingPlatformBorder");
    }

    private void Update()
    {
        SetDirection();
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
