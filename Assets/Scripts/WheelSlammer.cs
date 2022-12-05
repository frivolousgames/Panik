using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WheelSlammer : MonoBehaviour
{
    public GameObject backWheel;
    public GameObject frontWheel;
    public static bool oneLanded;
    public static bool bothLanded;

    public UnityEvent slamTime;

    public static string wheelName;

    private void Update()
    {
        Debug.Log("Both Landed: " + bothLanded);
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.gameObject.name == "Ground")
        {
            if (bothLanded == false)
            {
                if (oneLanded == false)
                {
                    oneLanded = true;
                    if (gameObject.name == "BackWheelCollider")
                    {
                        Debug.Log("Back Wheel Touched");
                        wheelName = "front wheel";
                    }
                    else
                    {
                        wheelName = "back wheel";
                        Debug.Log("Front Wheel Touched");
                    }
                    slamTime.Invoke();
                    Debug.Log("Slammed");
                }
                else
                {
                    
                    bothLanded = true;
                    oneLanded = false;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Ground")
        {
            bothLanded = false;
        }
    }
}
