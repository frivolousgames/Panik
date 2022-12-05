using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMissileDestroyed : MonoBehaviour
{
    GameObject[] enemies;

    public GameObject missileBody;
    public GameObject smoke;
    public GameObject flame;
    ParticleSystem.MainModule ps;

    Rigidbody2D rb;
    BoxCollider2D col;

    public GameObject explosion;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        ps = smoke.GetComponent<ParticleSystem>().main;
    }

    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("EnemyHitCollider");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (enemies != null)
        {
            foreach (GameObject enemy in enemies)
            {
                if (other.gameObject == enemy)
                {
                    missileBody.SetActive(false);
                    Destroy(flame);
                    col.enabled = false;
                    rb.velocity = new Vector2(2f, 0f);
                    //rb.gravityScale = 1f;
                    ps.loop = false;
                    ps.startLifetime = 0f;
                    SpawnExplosion();
                }
            }
        }
    }
    void SpawnExplosion()
    {
        GameObject exPrefab = Instantiate(explosion, transform.position, Quaternion.identity, null);
        ParticleSystem.MainModule psm = exPrefab.GetComponentInChildren<ParticleSystem>().main;
        Color orange = new Color(255, 140, 0);
        psm.startColor = new ParticleSystem.MinMaxGradient(orange);
        Debug.Log("Orange");
    }
    
}
