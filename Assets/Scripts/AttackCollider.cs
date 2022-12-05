using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    GameObject player;
    Transform parentTrans;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        parentTrans = transform.parent.transform;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            if(player.transform.position.x < parentTrans.position.x)
            {
                parentTrans.localScale = new Vector2(-1, parentTrans.localScale.y);
            }
            else
            {
                parentTrans.localScale = new Vector2(1, parentTrans.localScale.y);
            }
        }
    }
}
