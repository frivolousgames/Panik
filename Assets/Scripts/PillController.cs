using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PillController : MonoBehaviour
{
    GameObject player;

    private void Awake()
    {
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PhysicalCollider");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            if(SanityMeter.sanityAmount < 100)
            {
                SanityMeter.sanityAmount += 10;
                StartCoroutine("PillDestroy");
            }
        }
    }

    IEnumerator PillDestroy()
    {
        
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }

}
