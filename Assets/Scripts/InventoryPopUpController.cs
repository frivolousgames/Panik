using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPopUpController : MonoBehaviour
{
    bool canUse;
    bool canSell;
    bool canDiscard;

    GameObject canvas;

    public GameObject confirmBox;
    public GameObject confirmBoxTextObject;
    Text confirmBoxText;
    string confirmUseText;
    string confirmSellText;
    string confirmDiscardText;

    public GameObject denyBox;
    GameObject denyBoxPrefab;

    private void OnEnable()
    {
        canvas = GameObject.FindGameObjectWithTag("InventoryCanvas");
        SetButtons(GameController.inventoryObjectName);
        confirmBoxText = confirmBoxTextObject.GetComponent<Text>();
    }

    public void Use()
    {
        if(canUse == true)
        {
            GameController.inventoryObjectSelection = "Use";
            confirmBox.SetActive(true);
            
            confirmBoxText.text = confirmUseText;
            gameObject.SetActive(false);
        }
        else
        {
            denyBoxPrefab = Instantiate(denyBox, canvas.transform);
            gameObject.SetActive(false);
        }
    }

    public void Sell()
    {
        if (canSell == true)
        {
            GameController.inventoryObjectSelection = "Sell";
            confirmBox.SetActive(true);
            
            confirmBoxText.text = confirmSellText;
            gameObject.SetActive(false);
        }
        else
        {
            denyBoxPrefab = Instantiate(denyBox, canvas.transform);
            gameObject.SetActive(false);
        }
    }

    public void Discard()
    {
        if (canDiscard == true)
        {
            GameController.inventoryObjectSelection = "Discard";
            confirmBox.SetActive(true);
            
            confirmBoxText.text = confirmDiscardText;
            gameObject.SetActive(false);
        }
        else
        {
            denyBoxPrefab = Instantiate(denyBox, canvas.transform);
            gameObject.SetActive(false);
        }
    }

    void SetButtons(string name)
    {
        switch (name)
        {
            case "HatSlot":
                canUse = GameController.hatUsable;
                canSell = false;
                canDiscard = false;
                confirmUseText = "Use Hat?";
                break;
            case "ChipSlot":
                canUse = GameController.chipUsable;
                canSell = false;
                canDiscard = false;
                confirmUseText = "Use Chip?";
                break;
            case "BatterySlot":
                canUse = GameController.batteryUsable;
                canSell = false;
                canDiscard = false;
                confirmUseText = "Use Battery?";
                break;
            case "DynamiteSlot":
                canUse = GameController.dynamiteUsable;
                canSell = false;
                canDiscard = false;
                confirmUseText = "Use Dynamite?";
                break;
            case "ChuteSlot":
                canUse = false;
                canSell = GameController.sellable;
                canDiscard = true;
                confirmSellText = "Sell Chute for $20?";
                confirmDiscardText = "Discard Chute?";
                break;
            case "BalloonSlot":
                canUse = GameController.balloonUsable;
                canSell = GameController.sellable;
                canDiscard = true;
                confirmUseText = "Use Balloon?";
                confirmSellText = "Sell Balloon for $50?";
                confirmDiscardText = "Discard Balloon?";
                break;
            case "VodkaSlot":
                canUse = GameController.VodkaUsable();
                canSell = GameController.sellable;
                canDiscard = true;
                confirmUseText = "Use Vodka?";
                confirmSellText = "Sell Vodka for $1?";
                confirmDiscardText = "Discard Vodka?";
                break;
            case "LithiumSlot":
                canUse = GameController.LithiumUsable();
                canSell = GameController.sellable;
                canDiscard = true;
                confirmUseText = "Use Lithium?";
                confirmSellText = "Sell Lithium for $5?";
                confirmDiscardText = "Discard Lithium?";
                break;
            case "BazookaSlot":
                canUse = false;
                canSell = GameController.sellable;
                canDiscard = true;
                confirmSellText = "Sell Bazooka for $20?";
                confirmDiscardText = "Discard Bazooka?";
                break;
            case "DefaultGunSlot":
                canUse = false;
                canSell = false;
                canDiscard = false;
                break;
            case "FlamethrowerSlot":
                canUse = false;
                canSell = GameController.sellable;
                canDiscard = true;
                confirmSellText = "Sell Flamethrower for $20?";
                confirmDiscardText = "Discard Bazooka?";
                break;
        }
    }
    
}
