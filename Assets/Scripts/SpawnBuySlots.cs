using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBuySlots : MonoBehaviour
{
    GameObject slot01Prefab;
    GameObject slot02Prefab;
    GameObject slot03Prefab;

    public GameObject itemSlot;

    public Transform slot01SpawnPos;
    public Transform slot02SpawnPos;
    public Transform slot03SpawnPos;

    bool spawned;


    private void Update()
    {
        if(spawned != true)
        {
            if (GameController.slot01 != null)
            {
                slot01Prefab = Instantiate(itemSlot, slot01SpawnPos.position, Quaternion.identity, transform);
                slot01Prefab.GetComponent<Text>().text = GameController.slot01;

                slot02Prefab = Instantiate(itemSlot, slot02SpawnPos.position, Quaternion.identity, transform);
                slot02Prefab.GetComponent<Text>().text = GameController.slot02;

                slot03Prefab = Instantiate(itemSlot, slot03SpawnPos.position, Quaternion.identity, transform);
                slot03Prefab.GetComponent<Text>().text = GameController.slot03;

                spawned = true;
            }
        }
        //Debug.Log("Name " + slot01Prefab.name);
    }
}
