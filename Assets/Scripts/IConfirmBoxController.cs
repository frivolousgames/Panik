using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IConfirmBoxController : MonoBehaviour
{
    GameObject playerInactiveContainer;
    GameObject balloon;

    private void Awake()
    {
        playerInactiveContainer = GameObject.FindGameObjectWithTag("PlayerInactiveContainer");
        balloon = playerInactiveContainer.transform.GetChild(0).gameObject;
        //Debug.Log("Select + Name " + GameController.inventoryObjectSelection + GameController.inventoryObjectName);
    }

    public void TapYes()
    {

        SetSelection(GameController.inventoryObjectSelection, GameController.inventoryObjectName);
        gameObject.SetActive(false);
    }

    public void TapNo()
    {
        gameObject.SetActive(false);
    }

    void SetSelection(string selection, string slotName)
    {
        switch(selection + slotName)
        {
            //Hat
            case "Use" + "HatSlot":
                //unlock quest item ability
                PlayerPrefs.SetString("Hat", "False");
                GameController.hatUsed = true;
                SceneManager.UnloadSceneAsync("Inventory");
                break;

            //Chip
            case "Use" + "ChipSlot":
                //unlock quest item ability
                PlayerPrefs.SetString("Chip", "False");
                GameController.chipUsed = true;
                SceneManager.UnloadSceneAsync("Inventory");
                break;

            //Battery
            case "Use" + "BatterySlot":
                //unlock quest item ability
                PlayerPrefs.SetString("Battery", "False");
                GameController.batteryUsed = true;
                PlayerPrefs.SetString("Halluciphone_Awake", "True");
                SceneManager.UnloadSceneAsync("Inventory");
                break;
            //Dynamite
            case "Use" + "DynamiteSlot":
                //unlock quest item ability
                //PlayerPrefs.SetString("Dynamite", "False");
                PlayerPrefs.SetInt("Dynamite_Amount", 0);
                GameController.dynamiteUsed = true;
                SceneManager.UnloadSceneAsync("Inventory");
                break;
            //Chute
            case "Sell" + "ChuteSlot":
                PlayerPrefs.SetString("Chute", "False");
                MoneyAmount.moneyAmount += 20;
                break;
            case "Discard" + "ChuteSlot":
                PlayerPrefs.SetString("Chute", "False");
                break;
            //Balloon
            case "Use" + "BalloonSlot":
                balloon.SetActive(true);
                SceneManager.UnloadSceneAsync("Inventory");
                break;
            case "Sell" + "BalloonSlot":
                PlayerPrefs.SetString("Balloon", "False");
                MoneyAmount.moneyAmount += 50;
                break;
            case "Discard" + "BalloonSlot":
                PlayerPrefs.SetString("Balloon", "False");
                break;

            //Flamethrower
            case "Sell" + "FlamethrowerSlot":
                PlayerPrefs.SetString("Flamethrower", "False");
                MoneyAmount.moneyAmount += 20;
                break;
            case "Discard" + "FlamethrowerSlot":
                PlayerPrefs.SetString("Flamethrower", "False");
                break;

            //Bazooka
            case "Sell" + "BazookaSlot":
                PlayerPrefs.SetString("Bazooka", "False");
                MoneyAmount.moneyAmount += 20;
                break;
            case "Discard" + "BazookaSlot":
                PlayerPrefs.SetString("Bazooka", "False");
                break;

            //Vodka
            case "Use" + "VodkaSlot":
                int i = PlayerPrefs.GetInt("Vodka_Amount", 0);
                PlayerPrefs.SetInt("Vodka_Amount", i - 1);
                PlayerHealth.health += 10;
                break;
            case "Sell" + "VodkaSlot":
                int j = PlayerPrefs.GetInt("Vodka_Amount", 0);
                PlayerPrefs.SetInt("Vodka_Amount", j - 1);
                MoneyAmount.moneyAmount += 1;
                break;
            case "Discard" + "VodkaSlot":
                int k = PlayerPrefs.GetInt("Vodka_Amount", 0);
                PlayerPrefs.SetInt("Vodka_Amount", k - 1);
                break;

            //Lithium
            case "Use" + "LithiumSlot":
                int l = PlayerPrefs.GetInt("Lithium_Amount", 0);
                PlayerPrefs.SetInt("Lithium_Amount", l - 1);
                //send to sanity
                break;
            case "Sell" + "LithiumSlot":
                int m = PlayerPrefs.GetInt("Lithium_Amount", 0);
                PlayerPrefs.SetInt("Lithium_Amount", m - 1);
                MoneyAmount.moneyAmount += 5;
                break;
            case "Discard" + "LithiumSlot":
                int n = PlayerPrefs.GetInt("Lithium_Amount", 0);
                PlayerPrefs.SetInt("Lithium_Amount", n - 1);
                break;
        }
    }


}
