using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverParenting : MonoBehaviour
{
    GameObject player;
    BoxCollider2D playerCol;

    public static bool isMovingPlatform;

    bool parented;
    public float waitTime = 0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if(PlayerCollision.isBelow != true)
        {
            if (other == playerCol)
            {
                if (parented == false)
                {
                    player.transform.parent = gameObject.transform;
                    parented = true;
                }
            }
        }  
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == playerCol)
        {
            player.transform.parent = null;
            parented = false;
            waitTime = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
            if (other == playerCol)
            {
            waitTime += .1f;
                if (parented == false)
                {
                    if(waitTime > .2f)
                    {
                    player.transform.parent = gameObject.transform;
                    parented = true;
                    }
                    
                }
            }
    }

    private void Update()
    {
        //Debug.Log("Player : " + playerRb.velocity);
        //Debug.Log("Platform : " + rb.velocity);
    }
}
