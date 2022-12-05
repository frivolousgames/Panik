using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByEnemyContact : MonoBehaviour
{
    GameObject[] enemies;
    public GameObject explosion;

    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("EnemyHitCollider");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(enemies != null)
        {
            foreach(GameObject enemy in enemies)
            {
                if (other.gameObject == enemy)
                {
                    Instantiate(explosion, transform.position/* + parentTrans.position / 2*/, Quaternion.identity, null);
                    Destroy(gameObject);
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (enemies != null)
        {
            foreach (GameObject enemy in enemies)
            {
                if (other.gameObject == enemy)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (enemies != null)
        {
            foreach (GameObject enemy in enemies)
            {
                if (other.gameObject == enemy)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
