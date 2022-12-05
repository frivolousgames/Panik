using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotSpawn;

    public void ShootNow()
    {
        Instantiate(bullet, shotSpawn.position, Quaternion.identity, transform.parent);
    }
}
