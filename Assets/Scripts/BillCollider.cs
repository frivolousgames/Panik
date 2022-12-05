using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillCollider : MonoBehaviour
{
    public GameObject billScreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            billScreen.SetActive(true);
        }
    }
}
