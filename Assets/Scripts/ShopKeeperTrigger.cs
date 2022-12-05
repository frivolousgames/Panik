using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ShopKeeperTrigger : MonoBehaviour
{
    public GameObject player;
    public UnityEvent freeze;
    public string storeInventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            SceneManager.LoadScene(storeInventory, LoadSceneMode.Additive);
            freeze.Invoke();
        }
    }
}
