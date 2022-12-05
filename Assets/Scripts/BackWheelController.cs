using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWheelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ground")
        {
            Debug.Log("BackWheelTouching");
        }
    }
}
