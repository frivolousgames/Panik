using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryScreen : MonoBehaviour
{
    //For each new item:

        //GameController:
            //1. create public static bool hasItem
                //a. If item has amount create public static int itemAmount 
                //b. if itemAmount is limited, create public static bool itemFull
                //c. create ItemAmount method and put in Update
            //2. create public static bool itemUsable
                //a. if weapon, create public static bool weaponName
                //b. add to HasGun method
                //c. add to SetGunBool method
            //3. create public static bool itemUsed
            //4. create HasItem method and put in Update
                
       //This script:
            //1. create public Gameobject itemslotIcon
                //a. If item has amount, create public Text itemAmount
                //b. link itemAmount.text to GameController.itemAmount.ToString() in Awake and Update
            //2. create SetItemIcon method and place in Awake and Update

       //InventoryPopupController:
            //1. Add item to SetButtons method

       //IConfirmBoxController:
            //1. Add item to SetSelection method

       //Editor:
            //1. create ItemSlot GameObject
            //2. drag to SceneManager GameObject slot
                //a. if item has amount create Text gameobject and drag to SceneManager itemAmount

       //Optional:
            // create Mystery prize and/or Item Received screen animations
            

    //Items

    public GameObject hatSlotIcon;
    public GameObject chipSlotIcon;
    public GameObject batterySlotIcon;
    public GameObject chuteSlotIcon;
    public GameObject vodkaSlotIcon;
    public GameObject lithiumSlotIcon;
    public GameObject dynamiteSlotIcon;


    public Text vodkaAmount;
    public Text lithiumAmount;
    public Text dynamiteAmount;

    //Guns
    public GameObject bazookaSlotIcon;
    public GameObject flamethrowerSlotIcon;
    //public GameObject defaultgunSlotIcon;

    //Scene

    public GameObject inventoryScreen;

    private void Awake()
    {

        //Items
        SetChuteIcon();
        SetChipIcon();
        SetHatIcon();
        SetVodkaIcon();
        SetLithiumIcon();
        SetBatteryIcon();
        SetDynamiteIcon();

        //Guns
        SetBazookaIcon();
        SetFlamethrowerIcon();

        vodkaAmount.text = GameController.vodkaAmount.ToString();
        lithiumAmount.text = GameController.lithiumAmount.ToString();
        dynamiteAmount.text = GameController.dynamiteAmount.ToString();
    }

    private void Update()
    {

        //Items
        SetChuteIcon();
        SetHatIcon();
        SetChipIcon();
        SetVodkaIcon();
        SetLithiumIcon();
        SetBatteryIcon();
        SetDynamiteIcon();

        //Guns
        SetBazookaIcon();
        SetFlamethrowerIcon();

        vodkaAmount.text = GameController.vodkaAmount.ToString();
        lithiumAmount.text = GameController.lithiumAmount.ToString();
        dynamiteAmount.text = GameController.dynamiteAmount.ToString();

        if (!inventoryScreen.activeInHierarchy)
        {
            SceneManager.UnloadSceneAsync("Inventory");
        }
    }

    private void OnDestroy()
    {
        //Debug.Log("InventoryClosed");
    }

    //Items

    void SetHatIcon()
    {
        if (GameController.hasHat == true)
        {
            if (hatSlotIcon.activeInHierarchy != true)
            {
                hatSlotIcon.SetActive(true);

            }
        }
        else
        {
            hatSlotIcon.SetActive(false);
        }
    }

    void SetChipIcon()
    {
        if (GameController.hasChip == true)
        {
            if (chipSlotIcon.activeInHierarchy != true)
            {
                chipSlotIcon.SetActive(true);

            }
        }
        else
        {
            chipSlotIcon.SetActive(false);
        }
    }

    void SetBatteryIcon()
    {
        if (GameController.hasBattery == true)
        {
            if (batterySlotIcon.activeInHierarchy != true)
            {
                batterySlotIcon.SetActive(true);

            }
        }
        else
        {
            batterySlotIcon.SetActive(false);
        }
    }

    void SetChuteIcon()
    {
        if (GameController.hasChute == true)
        {
            if (chuteSlotIcon.activeInHierarchy != true)
            {
                chuteSlotIcon.SetActive(true);

            }
        }
        else
        {
            chuteSlotIcon.SetActive(false);
        }
    }

    void SetDynamiteIcon()
    {
        if (GameController.hasDynamite == true)
        {
            if (dynamiteSlotIcon.activeInHierarchy != true)
            {
                dynamiteSlotIcon.SetActive(true);

            }
        }
        else
        {
            chuteSlotIcon.SetActive(false);
        }
    }
    void SetVodkaIcon()
    {
        if (GameController.hasVodka == true)
        {
            if (vodkaSlotIcon.activeInHierarchy != true)
            {
                vodkaSlotIcon.SetActive(true);

            }
        }
        else
        {
            vodkaSlotIcon.SetActive(false);
        }
    }
    void SetLithiumIcon()
    {
        if (GameController.hasLithium == true)
        {
            if (lithiumSlotIcon.activeInHierarchy != true)
            {
                lithiumSlotIcon.SetActive(true);

            }
        }
        else
        {
            lithiumSlotIcon.SetActive(false);
        }
    }

    //Guns

    void SetBazookaIcon()
    {
        if (GameController.hasBazooka == true)
        {
            if (bazookaSlotIcon.activeInHierarchy != true)
            {
                bazookaSlotIcon.SetActive(true);

            }
        }
        else
        {
            bazookaSlotIcon.SetActive(false);
        }
    }
    void SetFlamethrowerIcon()
    {
        if (GameController.hasFlamethrower == true)
        {
            if (flamethrowerSlotIcon.activeInHierarchy != true)
            {
                flamethrowerSlotIcon.SetActive(true);

            }
        }
        else
        {
            flamethrowerSlotIcon.SetActive(false);
        }
    }
}
