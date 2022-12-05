using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStand_01 : GroundEnemy
{

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCol = GetComponent<EdgeCollider2D>();
        rb.velocity = Vector2.zero;
        chill = true;
    }

    private void Update()
    {
        anim.SetBool("Chill", chill);
        
        if (dead != true)
        {
            if (GameController.freezeAll != true)
            {
                Shoot();  
            }
        }
    }

    
}
