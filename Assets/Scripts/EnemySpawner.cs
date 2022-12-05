using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    GameObject player;
    //public string enemyScene;

    public GameObject enemy;
    Vector2 spawnPosition;
    public Transform spawnPosTrans;
    
    public float spawnRotation;
    public Vector3 scale;
    public bool enemyStanding;
    public Transform enemyParent;
    GameObject enemyPrefab;

    public bool twoSided;
    bool inFront;
    Vector2 altSpawnPosition;
    //public Transform altSpawnPosTrans;
    public Vector2 altSpawnOffset;

    public bool constantSpawn;
    public int prefabLimit;
    public Vector3 altScale;

    Vector3 spawnPosPrefab;
    Vector3 spawnScalePrefab;

    public Transform enemyParentGroup;
    int totalEnemiesInGroup;
    public float spawnWaitMin;
    public float spawnWaitMax;


    private void Awake()
    {
        spawnPosition = spawnPosTrans.position;
        altSpawnPosition = spawnPosition + altSpawnOffset;
        player = GameObject.FindGameObjectWithTag("PhysicalCollider");
        spawnPosPrefab = spawnPosition;
        spawnScalePrefab = scale;  
    }

    private void Update()
    {
        Loaded();
        IsTwoSided();
        if(enemyParentGroup != null)
        {
            totalEnemiesInGroup = enemyParentGroup.childCount;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if(constantSpawn == true)
            {
                StopAllCoroutines();
                StartCoroutine(StartConstantSpawn());
            }
            else
            {
                if (Loaded() == false)
                {
                    Debug.Log("Loaded: " + Loaded());
                    enemyPrefab = Instantiate(enemy, spawnPosPrefab, Quaternion.Euler(0, 0, spawnRotation), enemyParent);
                    enemyPrefab.transform.localScale = spawnScalePrefab;
                    EnemyStanding();
                    if (player.transform.position.x < transform.position.x)
                    {
                        inFront = false;
                    }
                    else
                    {
                        inFront = true;
                    }
                }
            }
        }
    }

    /*private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (Loaded() == true)
            {
                while(constantSpawn == true)
                {
                    enemyPrefab = Instantiate(enemy, spawnPosPrefab, Quaternion.Euler(0, 0, spawnRotation), enemyParent);
                    enemyPrefab.transform.localScale = spawnScalePrefab;
                    EnemyStanding();
                    if (player.transform.position.x < transform.position.x)
                    {
                        inFront = false;
                    }
                    else
                    {
                        inFront = true;
                    }


                }
                
            }
        }
    }*/

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (constantSpawn == true)
            {
                StopCoroutine(StartConstantSpawn());
            }
        }
    }

    IEnumerator StartConstantSpawn()
    {
        while (totalEnemiesInGroup < prefabLimit)
        {
            enemyPrefab = Instantiate(enemy, spawnPosPrefab, Quaternion.Euler(0, 0, spawnRotation), enemyParentGroup);
            enemyPrefab.transform.localScale = spawnScalePrefab;
            if (player.transform.position.x < transform.position.x)
            {
                inFront = false;
            }
            else
            {
                inFront = true;
            }
            yield return new WaitForSeconds(Random.Range(spawnWaitMin, spawnWaitMax));
        }
    }

    bool Loaded()
    {
        if(enemyPrefab == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    void EnemyStanding()
    {
        if(enemyStanding == true)
        {
            enemyPrefab.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    void IsTwoSided()
    {
        if(twoSided == true)
        {
            if(inFront == true)
            {
                spawnPosPrefab = altSpawnPosition;
                spawnScalePrefab = altScale;
            }
            else
            {
                spawnPosPrefab = spawnPosition;
                spawnScalePrefab = scale;
            }
        }
    }
}
