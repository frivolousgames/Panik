using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByDistance : MonoBehaviour
{
    public float deathDistance;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        DestroyWhenFar();
        //Debug.Log(Mathf.Abs((transform.position.x + transform.position.y) - (player.transform.position.x + player.transform.position.y)));
    }

    void DestroyWhenFar()
    {
        if(player != null)
        {
            if (Mathf.Abs((transform.position.x + transform.position.y) - (player.transform.position.x + player.transform.position.y)) > deathDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}
