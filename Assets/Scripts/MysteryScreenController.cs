using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MysteryScreenController : MonoBehaviour
{

    public TextMeshProUGUI mysteryPrizeText;
    public TextMeshProUGUI mysteryPrizeSummary;

    public GameObject dashIcon;
    public GameObject sackIcon;
    public GameObject helgaIcon;
    public GameObject vodkaIcon;
    public GameObject pinkGemIcon;

    public static string mysteryPrize;

    GameObject mysteryIcon;

    public float instWait;

    void OnEnable()
    {
        SelectMysteryPrize();
        SetMysteryPrize(mysteryPrize);
        StartCoroutine("IconWait");
    }

    void SetMysteryPrize(string randomPrize)
    {
        switch (randomPrize)
        {
            case "Dash":
                mysteryPrizeText.text = "Dash Attack";
                mysteryPrizeSummary.text = "Harm Enemies by Dashing Through Them";
                mysteryIcon = dashIcon;
                break;
            case "MoneySack":
                mysteryPrizeText.text = "Money Sack";
                WheelMoneyController.prizeAmount = 20;
                mysteryPrizeSummary.text = "+$20";
                mysteryIcon = sackIcon;
                break;
            case "Helga":
                mysteryPrizeText.text = "A Night With Helga";
                mysteryPrizeSummary.text = "She Is Very Sturdy Comrade";
                mysteryIcon = helgaIcon;
                break;
            case "Vodka":
                mysteryPrizeText.text = "Vodka";
                mysteryPrizeSummary.text = "It Refills Your Energy";
                mysteryIcon = vodkaIcon;
                break;
            case "PinkGem":
                mysteryPrizeText.text = "Pink Gem";
                WheelMoneyController.prizeAmount = 100;
                mysteryPrizeSummary.text = "+$100";
                mysteryIcon = pinkGemIcon;
                break;
            case null:
                mysteryPrizeText.text = "Oh Crap";
                mysteryPrizeSummary.text = "We Screwed Up";
                break;
            default:
                mysteryPrizeText.text = "Default Item";
                mysteryPrizeSummary.text = "Default Summary";
                break;
        }
    }
    void SelectMysteryPrize()
    {
        if (PlayerPrefs.GetString("Dash", "False") == "False")
        {
            mysteryPrize = "Dash";
        }
        else
        {
            int rand = Random.Range(0, 1000);
            if (rand < 501)
            {
                mysteryPrize = "MoneySack";
            }
            else if (rand > 500 & rand < 751)
            {
                mysteryPrize = "Helga";
            }
            else if (rand > 750 & rand < 901)
            {
                mysteryPrize = "Vodka";
            }
            else
            {
                mysteryPrize = "PinkGem";
            }
            Debug.Log("Rand = " + rand);
        }
    }

    IEnumerator IconWait()
    {
        yield return new WaitForSeconds(instWait);
        Instantiate(mysteryIcon, transform);
    }
}
