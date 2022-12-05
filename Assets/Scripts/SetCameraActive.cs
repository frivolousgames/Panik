using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraActive : MonoBehaviour
{
    public GameObject cam;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PhysicalCollider");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            if (cam.activeInHierarchy == false)
            {
                cam.SetActive(true);
            }
            else
            {
                cam.SetActive(false);

            }
        }
    }
}
