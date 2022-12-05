using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemReceivedController : MonoBehaviour
{
    public GameObject itemReceivedScreen;

    public TextMeshProUGUI receivedItemText;
    public TextMeshProUGUI receivedItemSummary;

    public GameObject dashIcon;
    public GameObject energyIcon;
    public GameObject sackIcon;
    public GameObject vodkaIcon;
    public GameObject greenGemIcon;
    public GameObject pinkGemIcon;
    public GameObject blueGemIcon;
    public GameObject batteryIcon;
    public GameObject chipIcon;
    public GameObject blueBalloonIcon;
    public GameObject hatIcon;
    public GameObject bazookaIcon;
    public GameObject flamethrowerIcon;
    public GameObject dynamiteIcon;
    public GameObject chuteIcon;

    public static string receivedItem;

    int prizeAmount;
    public float iSpawnWait;

    GameObject itemIcon;

    void OnEnable()
    {
        SetReceivedItem(receivedItem);
    }

    void SetReceivedItem(string itemName)
    {
        switch (itemName)
        {
            //Attacks
            case "Dash":
                receivedItemText.text = "Dash Attack";
                receivedItemSummary.text = "Dash Through Your Enemies";
                itemIcon = dashIcon;
                StartCoroutine("IconSpawnWait");
                break;
            case "Energy":
                receivedItemText.text = "Energy Attack";
                receivedItemSummary.text = "An Explosion Of Energy";
                itemIcon = energyIcon;
                StartCoroutine("IconSpawnWait");
                break;
            
            //Items
            case "Vodka":
                receivedItemText.text = "Vodka";
                receivedItemSummary.text = "It Refills Your Energy";
                itemIcon = vodkaIcon;
                StartCoroutine("IconSpawnWait");
                break;
            case "Chute":
                receivedItemText.text = "Chute";
                receivedItemSummary.text = "Tap Jump In The Air To Glide";
                itemIcon = chuteIcon;
                StartCoroutine("IconSpawnWait");
                break;
            case "Dynamite":
                receivedItemText.text = "Dynamite";
                receivedItemSummary.text = "It Blows Stuff Up";
                itemIcon = dynamiteIcon;
                StartCoroutine("IconSpawnWait");
                break;
            case "Hat":
                receivedItemText.text = "Small Hat";
                receivedItemSummary.text = "A Child's Hat";
                itemIcon = hatIcon;
                StartCoroutine("IconSpawnWait");
                break;
            case "Chip":
                receivedItemText.text = "Poker Chip";
                receivedItemSummary.text = "A Chip From A Casino";
                itemIcon = chipIcon;
                StartCoroutine("IconSpawnWait");
                break;
            case "Battery":
                receivedItemText.text = "Battery";
                receivedItemSummary.text = "It Provides Power";
                itemIcon = batteryIcon;
                StartCoroutine("IconSpawnWait");
                break;
            case "BlueBalloon":
                receivedItemText.text = "Blue Balloon";
                receivedItemSummary.text = "Helps You Float Sometimes";
                itemIcon = blueBalloonIcon;
                StartCoroutine("IconSpawnWait");
                break;

            //Guns
            case "Flamethrower":
                receivedItemText.text = "Flamethrower";
                receivedItemSummary.text = "Shoots A Burst Of Flames";
                itemIcon = flamethrowerIcon;
                StartCoroutine("IconSpawnWait");
                break;
            case "Bazooka":
                receivedItemText.text = "RPG";
                receivedItemSummary.text = "Rocket Powered Grenade Launcher";
                itemIcon = bazookaIcon;
                StartCoroutine("IconSpawnWait");
                break;

            //Money
            case "MoneySack":
                receivedItemText.text = "Money Sack";
                prizeAmount = 20;
                receivedItemSummary.text = "+$20";
                itemIcon = sackIcon;
                StartCoroutine("IconSpawnWait");
                break;
            case "GreenGem":
                receivedItemText.text = "Green Gem";
                prizeAmount = 50;
                receivedItemSummary.text = "+$50";
                itemIcon = greenGemIcon;
                StartCoroutine("IconSpawnWait");
                break;
            case "PinkGem":
                receivedItemText.text = "Pink Gem";
                prizeAmount = 75;
                receivedItemSummary.text = "+$75";
                itemIcon = pinkGemIcon;
                StartCoroutine("IconSpawnWait");
                break;
            case "BlueGem":
                receivedItemText.text = "Blue Gem";
                prizeAmount = 100;
                receivedItemSummary.text = "+$100";
                itemIcon = blueGemIcon;
                StartCoroutine("IconSpawnWait");
                break;

            case null:
                receivedItemText.text = "Oh Crap";
                receivedItemSummary.text = "We Screwed Up";
                break;
            default:
                receivedItemText.text = "Default Item";
                receivedItemSummary.text = "Default Summary";
                break;
        }
    }

    public void CloseItemReceivedScreen()
    {
        //Debug.Log(MysteryScreenController.mysteryPrize);
        switch (receivedItem)
        {
            //Attacks
            case "Dash":
                PlayerPrefs.SetString("Dash", "True");
                itemReceivedScreen.SetActive(false);
                break;
            case "Energy":
                break;

            //Items
            case "Vodka":
                if (GameController.vodkaFull != true)
                {
                    int amount = PlayerPrefs.GetInt("Vodka_Amount", 0);
                    PlayerPrefs.SetInt("Vodka_Amount", amount + 1);
                }
                else
                {
                    Debug.Log("Vodka is Full");
                }
                itemReceivedScreen.SetActive(false);
                break;
            case "Chute":
                PlayerPrefs.SetString("Chute", "True");
                itemReceivedScreen.SetActive(false);
                break;
            case "Dynamite":
                int dAmount = PlayerPrefs.GetInt("Dynamite_Amount", 0);
                PlayerPrefs.SetInt("Dynamite_Amount", dAmount + 1);
                itemReceivedScreen.SetActive(false);
                break;
            case "Hat":
                PlayerPrefs.SetString("Hat", "True");
                itemReceivedScreen.SetActive(false);
                break;
            case "Chip":
                PlayerPrefs.SetString("Chip", "True");
                itemReceivedScreen.SetActive(false);
                break;
            case "Battery":
                PlayerPrefs.SetString("Battery", "True");
                itemReceivedScreen.SetActive(false);
                break;
            case "BlueBalloon":
                PlayerPrefs.SetString("BlueBalloon", "True");
                itemReceivedScreen.SetActive(false);
                break;

            //Guns
            case "Flamethrower":
                PlayerPrefs.SetString("Flamethrower", "True");
                itemReceivedScreen.SetActive(false);
                break;
            case "Bazooka":
                PlayerPrefs.SetString("Bazooka", "True");
                itemReceivedScreen.SetActive(false);
                break;
            
                //Money
            case "MoneySack":
                StartCoroutine("AddReceivedMoney");
                break;
            case "GreenGem":
                StartCoroutine("AddReceivedMoney");
                break;
            case "PinkGem":
                StartCoroutine("AddReceivedMoney");
                break;
            case "BlueGem":
                StartCoroutine("AddReceivedMoney");
                break;
            
            default:
                Debug.LogError("No String Selected!");
                itemReceivedScreen.SetActive(false);
                break;
        }
    }

    IEnumerator IconSpawnWait()
    {
        yield return new WaitForSeconds(iSpawnWait);
        Instantiate(itemIcon, transform);
    }

    IEnumerator AddReceivedMoney()
    {
        while(prizeAmount > 0)
        {
            prizeAmount--;
            MoneyAmount.moneyAmount++;
            receivedItemSummary.text = "+$" + prizeAmount.ToString();
            yield return new WaitForSeconds(.05f);
        }
        yield return new WaitForSeconds(0.8f);
        itemReceivedScreen.SetActive(false);
    }
}
