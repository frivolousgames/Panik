using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    public GameObject[] weaponBubbles;
    //Animator anim;

    List<string> guns;
    string defaultGun;
    string bazooka;
    string flamethrower;

    public GameObject weaponRing;
    public GameObject weaponRingIcon;
    //GameObject newBubblePrefab;

    public Sprite defaultGunIcon;
    public Sprite flamethrowerIcon;
    public Sprite bazookaIcon;
    public Sprite empty;

    public GameObject equippedGunIcon;

    //public GameObject fireBar;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
        defaultGun = "defaultGun";
        bazooka = "bazooka";
        flamethrower = "flamethrower";
        guns = new List<string>();
        SetActiveGunIcon();
    }

    private void Update()
    {
        SetActiveGunIcon();
        //Debug.Log("Guns " + guns.Count);


        //Debug.Log("Gun Icon " + equippedGunIcon.GetComponent<Image>().sprite.name);
    }

    public void ActivateWeaponRing()
    {
        guns.Clear();
        weaponRing.SetActive(true);
        //weaponRingIcon.GetComponent<Image>().sprite = equippedGunIcon.GetComponent<Image>().sprite;
        CollectGuns();

        if (guns.Count > 0)
        {
            int i = 0;
            foreach (string gun in guns)
                {
                //for (int i = 0; i < guns.Count; i++)
                //{
                    
                    weaponBubbles[i].GetComponentInChildren<Text>().text = gun;
                    weaponBubbles[i].SetActive(true);
                    i++;
                    //Debug.Log("Gun " + gun);
                    //}
                        
                }
        }
       
    }

    void CollectGuns()
    {
        if (GameController.hasDefaultGun && GameController.defaultGun != true)
        {
            guns.Add(defaultGun);
        }
        if (GameController.hasBazooka && GameController.bazooka != true)
        {
            guns.Add(bazooka);
        }
        if (GameController.hasFlamethrower && GameController.flamethrower != true)
        {
            guns.Add(flamethrower);
        }
    }

    void SetActiveGunIcon()
    {
      
        if(GameController.equippedGun == "FlameThrower")
        {
            equippedGunIcon.GetComponent<Image>().sprite = flamethrowerIcon;
            //fireBar.SetActive(true);
        }
        else if (GameController.equippedGun == "Bazooka")
        {
            equippedGunIcon.GetComponent<Image>().sprite = bazookaIcon;
            //fireBar.SetActive(false);
        }
        else if (GameController.equippedGun == "Default_gun")
        {
            equippedGunIcon.GetComponent<Image>().sprite = defaultGunIcon;
            //fireBar.SetActive(false);
        }
        else
        {
            equippedGunIcon.GetComponent<Image>().sprite = empty;
            //fireBar.SetActive(false);
        }
    }
    
}
