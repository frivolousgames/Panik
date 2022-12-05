using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTalkTextName : MonoBehaviour
{
    GameObject player;

    public static GameObject myName;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            myName = gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            myName = null;
        }
    }
}
