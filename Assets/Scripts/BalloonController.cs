using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public Animator anim;
    GameObject container;
    GameObject player;
    Rigidbody2D rb;
    public float popForce;

    private void Awake()
    {
        container = transform.parent.gameObject;
        player = container.transform.parent.gameObject;
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("CeilingCollider"))
        {
            anim.SetTrigger("Pop");
            rb.AddForce(Vector2.down * popForce, ForceMode2D.Impulse);
        }
    }


}
