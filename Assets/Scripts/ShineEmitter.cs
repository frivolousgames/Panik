using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShineEmitter : MonoBehaviour
{
    public GameObject shine;

    public Transform position1;
    public Transform position2;

    bool spawning = true;

    private void Start()
    {
        StartCoroutine("SpawnShines");
    }

    IEnumerator SpawnShines()
    {
        while(spawning == true)
        {
            Instantiate(shine, new Vector2(Random.Range(position1.position.x, position2.position.x), Random.Range(position1.position.y, position2.position.y)), Quaternion.identity, null);
            yield return new WaitForSeconds(.2f);
        }
    }
}
