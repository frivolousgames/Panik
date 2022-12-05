using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBats : MonoBehaviour
{
    GameObject player;

    public GameObject bats;
    public GameObject fakeBats;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            bats.SetActive(true);
            fakeBats.SetActive(false);
        }
    }
}
