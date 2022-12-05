using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkSpawn : MonoBehaviour
{
    public GameObject spark;
    public GameObject wheel;
    public Transform spawnPos;

    Collider2D col;


    private void Awake()
    {
        col = GetComponent<PolygonCollider2D>();
    }
    private void Update()
    {
        //spawnPos = new Vector2(wheel.transform.position.x + .2f, wheel.transform.position.y - .4f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == wheel)
        {
            //Instantiate(spark, col.bounds.ClosestPoint(wheel.transform.position), Quaternion.identity, null);
            Instantiate(spark, spawnPos.position, spawnPos.transform.rotation, spawnPos);
        }
    }
}
