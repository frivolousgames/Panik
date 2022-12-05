using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWeaponRing : MonoBehaviour
{
    public GameObject weaponRing;

    public void CloseRing()
    {
        weaponRing.SetActive(false);
        //WeaponButton.guns.Clear();

    }

}
