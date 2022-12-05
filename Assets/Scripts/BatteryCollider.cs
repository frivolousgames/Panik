using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCollider : MonoBehaviour
{
    private void Update()
    {
        Debug.Log("BU: " + GameController.batteryUsable);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(GameController.hasBattery == true)
            {
                GameController.batteryUsable = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GameController.batteryUsable == true)
            {
                GameController.batteryUsable = false;
            }
        }
    }

}
