using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatePopUp : MonoBehaviour
{
    GameObject popUp;

    private void Update()
    {
        popUp = GameObject.FindGameObjectWithTag("ItemPopUp");
    }

    public void DeastroyOnExit()
    {
        if(popUp != null)
        {
            Destroy(popUp);
        }
    }
}
