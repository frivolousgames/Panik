using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeAll : MonoBehaviour
{
    GameObject enemyParent;
    Animator[] animatedObjects;
    Rigidbody2D[] rbObjects;

    GameObject player;
    Animator playerAnim;
    Rigidbody2D playerRb;

    GameObject movingPlatformParent;
    Rigidbody2D[] rbObjects1;

    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerAnim = player.GetComponentInChildren<Animator>();
            playerRb = player.GetComponent<Rigidbody2D>();
        }
        
    }


    public void FreezeAllObjects()
    {
        enemyParent = GameObject.FindGameObjectWithTag("AnimatedEnemies");
        if(enemyParent!= null)
        {
            animatedObjects = enemyParent.GetComponentsInChildren<Animator>();
            rbObjects = enemyParent.GetComponentsInChildren<Rigidbody2D>();
        }
        
        movingPlatformParent = GameObject.FindGameObjectWithTag("MovingPlatform");
        if (movingPlatformParent != null)
        {
            rbObjects1 = movingPlatformParent.GetComponentsInChildren<Rigidbody2D>();
        }

        playerAnim.enabled = false;
        playerRb.velocity = Vector2.zero;
        playerRb.isKinematic = true;
        PlayerController.isFrozen = true;

        if (animatedObjects != null)
        {
            foreach (Animator anim in animatedObjects)
            {
                anim.enabled = false;
            }
        }
        if (rbObjects != null)
        {
            foreach (Rigidbody2D rb in rbObjects)
            {
                //rb.velocity = Vector2.zero;
                rb.simulated = false;
            }
        }
        if (rbObjects1 != null)
        {
            foreach (Rigidbody2D rb in rbObjects1)
            {
                //rb.velocity = Vector2.zero;
                rb.simulated = false;
            }
        }
        GameController.freezeAll = true;
    }
    public void UnFreezeAllObjects()
    {
        enemyParent = GameObject.FindGameObjectWithTag("AnimatedEnemies");
        if (enemyParent != null)
        {
            animatedObjects = enemyParent.GetComponentsInChildren<Animator>();
            rbObjects = enemyParent.GetComponentsInChildren<Rigidbody2D>();
        }
        movingPlatformParent = GameObject.FindGameObjectWithTag("MovingPlatform");
        if (movingPlatformParent != null)
        {
            rbObjects1 = movingPlatformParent.GetComponentsInChildren<Rigidbody2D>();
        }
        playerAnim.enabled = true;
        //playerRb.velocity = Vector2.zero;
        playerRb.isKinematic = false;
        PlayerController.isFrozen = false;

        if (animatedObjects != null)
        {
            foreach (Animator anim in animatedObjects)
            {
                anim.enabled = true;
            }
        }
        if (rbObjects != null)
        {
            foreach (Rigidbody2D rb in rbObjects)
            {
                //rb.velocity = Vector2.zero;
                rb.simulated = true;
            }
        }
        if (rbObjects1 != null)
        {
            foreach (Rigidbody2D rb in rbObjects1)
            {
                //rb.velocity = Vector2.zero;
                rb.simulated = true;
            }
        }
        GameController.freezeAll = false;
    }
}
