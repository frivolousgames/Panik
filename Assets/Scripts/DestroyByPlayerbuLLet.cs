using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByPlayerbuLLet : MonoBehaviour
{
    public GameObject explosion;
    public GameObject[] bullets;

    private void Update()
    {
        bullets = GameObject.FindGameObjectsWithTag("Default Bullet");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach(GameObject bullet in bullets)
        {
            if (other.gameObject == bullet)
            {
                Instantiate(explosion, transform.position, Quaternion.identity, null);
                Destroy(bullet);
                Destroy(gameObject);
            }
        }
    }
}
