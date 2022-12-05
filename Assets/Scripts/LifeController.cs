using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    GameObject player;
    public int boost;

    private void Awake()
    {
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PhysicalCollider");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (PlayerHealth.health < 100)
            {
                PlayerHealth.health += boost;
                StartCoroutine("PillDestroy");
            }
        }
    }

    IEnumerator PillDestroy()
    {

        yield return null;
        Destroy(gameObject);
    }
}
