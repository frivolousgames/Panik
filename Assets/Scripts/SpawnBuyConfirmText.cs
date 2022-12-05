using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuyConfirmText : MonoBehaviour
{
    public GameObject buyConfirmText;
    Transform confirmSpawnPos;
    bool buyable = true;

    private void Awake()
    {
        confirmSpawnPos = gameObject.transform;
    }

    public void SpawnConfirmText()
    {
        if(buyable == true)
        {
            Instantiate(buyConfirmText, confirmSpawnPos.position, Quaternion.identity, confirmSpawnPos);
        }
    }
}
