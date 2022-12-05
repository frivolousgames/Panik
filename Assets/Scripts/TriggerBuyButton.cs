using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBuyButton : MonoBehaviour
{
    public GameObject buyButton;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            if(buyButton.activeInHierarchy == false)
            {
                buyButton.SetActive(true);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            if (buyButton.activeInHierarchy == true)
            {
                buyButton.SetActive(false);

            }
        }
    }
}
