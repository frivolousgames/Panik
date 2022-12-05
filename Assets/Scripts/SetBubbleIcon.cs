using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBubbleIcon : MonoBehaviour
{
    public GameObject gunName;

    Image gunIcon;

    public Sprite defaultGunIcon;
    public Sprite flamethrowerIcon;
    public Sprite bazookaIcon;
    public Sprite empty;

    string gunNameText;
    string gun;

    public GameObject weaponRing;

    private void Awake()
    {
        //gunIcon = GetComponent<Image>();

    }

    private void Start()
    {
        //gunNameText = gunName.GetComponent<Text>().text;

        //SetIcon(gunNameText);

        //Debug.Log("GunName " + gunName.GetComponent<Text>().text);
    }
    private void OnEnable()
    {
        gunIcon = GetComponent<Image>();
        gunNameText = gunName.GetComponent<Text>().text;
        SetIcon(gunNameText);
    }

    void SetIcon(string name)
    {
        switch (name)
        {
            case "defaultGun":
                gunIcon.sprite = defaultGunIcon;
                gun = "Default_gun";
                break;
            case "flamethrower":
                gunIcon.sprite = flamethrowerIcon;
                gun = "FlameThrower";
                break;
            case "bazooka":
                gunIcon.sprite = bazookaIcon;
                gun = "Bazooka";
                break;
            case null:
                gunIcon.sprite = empty;
                break;
            default:
                gunIcon.sprite = empty;
                break;
        }
    }

    public void SelectWeapon()
    {
        if(gun != null)
        {
            GameController.equippedGun = gun;
            weaponRing.SetActive(false);
            //WeaponButton.guns.Clear();
        }
    }

}
