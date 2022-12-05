using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPopUpController : MonoBehaviour
{
    public GameObject popUp;

    public void SetPopUpInactive()
    {
        popUp.SetActive(false);
    }
}
