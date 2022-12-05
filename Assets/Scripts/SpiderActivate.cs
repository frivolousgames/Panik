using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpiderActivate : MonoBehaviour
{
    GameObject player;

    public Animator anim;

    public UnityEvent start;
    public UnityEvent reset;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PhysicalCollider");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            start.Invoke();
            //anim.SetTrigger("Start");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            reset.Invoke();
            //anim.SetTrigger("Reset");
        }
    }
}
