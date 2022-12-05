using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemPopUp : MonoBehaviour
{
    public GameObject popUp;

    public void SpawnPopUp()
    {
        if (popUp.activeInHierarchy == false)
        {
            GameController.inventoryObjectName = gameObject.name;
            popUp.SetActive(true);
        }
        else
        {
            popUp.SetActive(false);
        }
    }
}
