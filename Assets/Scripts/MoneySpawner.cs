using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    public int[] weight = { 80, 70, 60, 50, 20 };
    public int total;
    public int randomNumber;
    public List<GameObject> loot;
    public GameObject selectedMoney;
    public Transform lootDropSpawn;
    
    private void Awake()
    {
        foreach(int value in weight)
        {
            total += value;
        }
        
    }
    private void Start()
    {
        randomNumber = Random.Range(0, total);
        for (int i = 0; i < weight.Length; i++)
        {
            if (randomNumber <= weight[i])
            {
                selectedMoney = loot[i];
                return;
            }
            else
            {
                randomNumber -= weight[i];
            }

        }
    }

    private void Update()
    {
        
    }

    public void LootDrop()
    {
        Instantiate(selectedMoney, lootDropSpawn.position, Quaternion.identity, null);
    }

}
