using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    BoxCollider2D col;
    //EdgeCollider2D playerCol;
    //GameObject player;
    BoxCollider2D physCol;
    //public static bool isBelow;

    //public float rayBuffer;
    //LayerMask groundLayer;

    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
       // playerCol = player.GetComponent<EdgeCollider2D>();
        col = GetComponent<BoxCollider2D>();
        physCol = GameObject.FindGameObjectWithTag("PhysicalCollider").GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        //groundLayer = LayerMask.NameToLayer("Ground");
    }

    private void Update()
    {
        //ColliderCollision();
    }

    private void FixedUpdate()
    {
        Physics2D.IgnoreCollision(physCol, col);
        //RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + rayBuffer), Vector2.down, 5, groundLayer);
        //Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + rayBuffer), Vector2.down * 5, Color.blue);
    }

    /*void ColliderCollision()
    {
        if(player.transform.parent == null)
        {
            if (player.transform.position.y - 1.538f < transform.position.y)
            {
                Physics2D.IgnoreCollision(playerCol, col);
                isBelow = true;
            }
            else
            {
                Physics2D.IgnoreCollision(playerCol, col, false);
                isBelow = false;
            }
        }
        Physics2D.IgnoreCollision(physCol, col);
    }*/

    
}
