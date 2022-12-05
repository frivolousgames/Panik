using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public GameObject batExplosion;
    public Transform batExplosionSpawn;
    //GameObject[] bullets;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("PlayerHitCollider"))
        {
            StartCoroutine("Explode");
            
        }
    }
    IEnumerator ExplodeWait()
    {
        yield return new WaitForSeconds(.1f);
        Explode();
    }
    public void Explode()
    {
        Instantiate(batExplosion, batExplosionSpawn.position, Quaternion.identity, null);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
