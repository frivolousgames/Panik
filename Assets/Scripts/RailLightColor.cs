using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RailLightColor : MonoBehaviour
{
    public Collider2D col;
    public SpriteRenderer sr;

    bool isRotating;
    public float rotSpeed = 1;

    private void Update()
    {
        if(isRotating == true)
        {
            transform.Rotate(0f, 0f, -rotSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == col)
        {
            sr.color = Color.green;
            isRotating = false;
        }
    }

    public void SetRotation()
    {
        isRotating = true;
    }
}
