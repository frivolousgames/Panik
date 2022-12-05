using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStaticGround : GroundEnemy
{
    public GameObject volcanoExplode;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Start()
    {
        
    }
    
    void Update()
    {
        //Shoot();
    }

    private void FixedUpdate()
    {
        
    }

    override public void Killed()
    {
        dead = true;
        Instantiate(volcanoExplode, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //anim.SetTrigger("Die");
        //rb.velocity = Vector2.down * dieForce;
        //rb.AddForce(Vector2.up * dieUpForce, ForceMode2D.Impulse);
        //groundCol.isTrigger = true;
        //Destroy(borderCol);
    }

    public void ShootNow()
    {
        shotWaitTime = .1f;
        StartCoroutine("WaitTimeReset");
    }
    IEnumerator WaitTimeReset()
    {
        yield return new WaitForSeconds(.1f);
        shotWaitTime = 2f;
    }
}
