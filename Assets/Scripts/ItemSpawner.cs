using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject item;
    public Transform itemSpawn;

    public void SpawnItem()
    {
        Instantiate(item, itemSpawn.position, Quaternion.identity, null);
    }
}
