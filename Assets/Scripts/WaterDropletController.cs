using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropletController : MonoBehaviour
{
    public LayerMask groundLayer;
    bool hitGround;

    Vector3 startPos;

    public GameObject dropArt;
    Rigidbody2D rb;

    bool ready = true;

    public float dripWait;

    private void Awake()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        ready = true;
    }

    private void FixedUpdate()
    {
        hitGround = Physics2D.IsTouchingLayers(GetComponent<BoxCollider2D>(), groundLayer);   
    }

    private void Update()
    {
        SpawnSplash();
    }

    void SpawnSplash()
    {
        if(ready == true)
        {
            if (hitGround == true)
            {
                ready = false;
                
                rb.isKinematic = true;
                transform.position = startPos;
                rb.velocity = Vector2.zero;
                dropArt.SetActive(false);
                StartCoroutine("RespawnDelay");
            }
        } 
    }

    IEnumerator RespawnDelay()
    {
        yield return new WaitForSeconds(dripWait);
        ready = true;
        rb.isKinematic = false;
        dropArt.SetActive(true);
    }
}
