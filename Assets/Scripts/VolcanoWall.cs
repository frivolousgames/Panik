using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoWall : GroundEnemy
{
    public GameObject volcanoExplode;

    bool expand;
    public float idleTime;
    public float expandIdleTime;
    public float shootMulti;
    public float startWait;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim.SetBool("expand", expand);
        StartCoroutine("StartWait");
    }

    private void Update()
    {
        anim.SetBool("expand", expand);
    }

    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(startWait);
        StartCoroutine("ShootRoutine");
    }

    IEnumerator ShootRoutine()
    {
        yield return new WaitForSeconds(idleTime);
        expand = true;
        yield return new WaitForSeconds(expandIdleTime);
        for (int i = 0; i < shootMulti; i++)
        {
            anim.SetTrigger("shoot");
            yield return new WaitForSeconds(shootAnimTime);
            Instantiate(bullet, shotSpawn.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(shootAnimOutTime);
        }
        //yield return new WaitForSeconds(expandIdleTime);
        expand = false;
        StartCoroutine("ShootRoutine");
    }

    override public void Killed()
    {
        dead = true;
        Instantiate(volcanoExplode, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
