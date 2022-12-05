using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantStalagController : MonoBehaviour
{
    public Animator anim;
    bool started;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PhysicalCollider");
    }

    private void Update()
    {
        anim.SetBool("Started", started);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            started = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            started = false;
        }
    }
}
