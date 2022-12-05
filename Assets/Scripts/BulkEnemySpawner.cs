using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulkEnemySpawner : MonoBehaviour
{
    GameObject player;

    public GameObject[] enemies;
    public Vector2[] spawnPositions;
    public float[] spawnRotation;
    public Vector3[] xScale;
    public Transform enemyParent;
    GameObject[] enemyPrefab; 


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyPrefab = new GameObject[enemies.Length];
    }

    private void Update()
    {
        //Debug.Log("Loaded: " + Loaded());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (Loaded() == false)
            {
                for(int i = 0; i < enemies.Length; i++)
                {
                    enemyPrefab[i] = Instantiate(enemies[i], spawnPositions[i], Quaternion.Euler(0,0,spawnRotation[i]), enemyParent);
                    enemyPrefab[i].transform.localScale = xScale[i];
                }
            }
        }
    }

    bool Loaded()
    {
        for (int i = 0; i < enemyPrefab.Length; i++)
        {
            if(enemyPrefab[i] != null)
            {
                return true;
            } 
        }
        return false;
    }
}
