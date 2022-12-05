using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWeaponRingIcon : MonoBehaviour
{
    public Sprite defaultGunIcon;
    public Sprite flamethrowerIcon;
    public Sprite bazookaIcon;
    public Sprite empty;

    private void OnEnable()
    {
        SetActiveGunIcon();
    }

    void SetActiveGunIcon()
    {

        if (GameController.equippedGun == "FlameThrower")
        {
            GetComponent<Image>().sprite = flamethrowerIcon;
        }
        else if (GameController.equippedGun == "Bazooka")
        {
            GetComponent<Image>().sprite = bazookaIcon;
        }
        else if (GameController.equippedGun == "Default_gun")
        {
            GetComponent<Image>().sprite = defaultGunIcon;
        }
        else
        {
            GetComponent<Image>().sprite = empty;
        }
    }
}
