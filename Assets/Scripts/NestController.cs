using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestController : GroundEnemy
{
    public GameObject explosion;



    public override void Killed()
    {
        Instantiate(explosion,transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }
}
