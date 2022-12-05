using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetItem : MonoBehaviour
{
    public GameObject itemReceivedScreen;
    GameObject[] items;
    public UnityEvent freeze;

    private void OnTriggerEnter2D(Collider2D other)
    {
        items = GameObject.FindGameObjectsWithTag("Item");
        foreach(GameObject item in items)
        {
            if (other.gameObject == item)
            {
                ItemReceivedController.receivedItem = other.gameObject.name;
                freeze.Invoke();
                Destroy(other.gameObject); 
                itemReceivedScreen.SetActive(true);
            }
        }
    }
    private void Update()
    {
        //Debug.Log(ItemReceivedController.receivedItem);
    }
}
