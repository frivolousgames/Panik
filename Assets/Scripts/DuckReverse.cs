using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckReverse : MonoBehaviour
{
    public GameObject duck;
    //Rigidbody2D rb;

    private void Awake()
    {
        //rb = duck.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == duck)
        {
            //rb.velocity = Vector2.zero;
            duck.transform.localScale = new Vector2(-duck.transform.localScale.x, duck.transform.localScale.y);
        }
    }
}
