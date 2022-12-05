using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHallCam : MonoBehaviour
{
    public GameObject hallCam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(!hallCam.activeInHierarchy)
            {
                hallCam.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (hallCam.activeInHierarchy)
            {
                hallCam.SetActive(false);
            }
        }
    }
}
