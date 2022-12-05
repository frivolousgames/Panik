using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringCam : MonoBehaviour
{
    GameObject player;
    public GameObject zoomCam;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            zoomCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            zoomCam.SetActive(false);
        }
    }
}
