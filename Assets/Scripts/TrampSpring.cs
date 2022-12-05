using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampSpring : MonoBehaviour
{
    public Animator anim;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            anim.SetTrigger("Spring");
        }
    }

    public void SetSpringAnim()
    {
        anim.SetTrigger("Spring");
    }
}
