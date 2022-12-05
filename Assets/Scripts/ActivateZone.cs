using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateZone : MonoBehaviour
{
    public GameObject gasEmitter;
    BoxCollider2D player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PhysicalCollider").GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player)
        {
            if (gasEmitter.activeInHierarchy == false)
            {
                gasEmitter.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == player)
        {
            if (gasEmitter.activeInHierarchy == true)
            {
                gasEmitter.SetActive(false);
            }
        }
    }
}
