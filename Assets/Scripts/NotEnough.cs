using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnough : MonoBehaviour
{
    public GameObject notEnough;

    public void NotEnoughActive()
    {
        if (!notEnough.activeInHierarchy)
        {
            notEnough.SetActive(true);
        }
    }
}
