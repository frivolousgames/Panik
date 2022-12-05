using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoarObjects : MonoBehaviour
{
    public GameObject stalagmite;
    public GameObject bat;
    public static bool isBatty;
    bool isSpawning;
    public Transform sSpawn;

    public GameObject dustSpawner;

    public void DoStuff()
    {
        isSpawning = true;
        isBatty = false;
        StartCoroutine(SpawnStals());
        dustSpawner.SetActive(true);
        StartCoroutine("Stop");
    }

    IEnumerator SpawnStals()
    {
        while(isSpawning == true)
        {
            if (isBatty != false)
            {
                Instantiate(bat, new Vector2(Random.Range(-14.5f, -3f), sSpawn.position.y), Quaternion.identity, null);
                yield return new WaitForSeconds(.8f);
            }
            else
            {
                Instantiate(stalagmite, new Vector2(Random.Range(-14.5f, -3f), sSpawn.position.y), Quaternion.identity, null);
                yield return new WaitForSeconds(.2f);
            }
            
        }
       
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(1f);
        isSpawning = false;
        dustSpawner.SetActive(false);
    }
}
