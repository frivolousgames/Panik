using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmBoxController : MonoBehaviour
{
    public static string buyName;
    public static int price;

    int amount;

    public void ItemBought()
    {
        switch (buyName)
        {
            case "Vodka":
                PlayerPrefs.SetString("Vodka", "True");
                amount = PlayerPrefs.GetInt("Vodka_Amount", 0);
                PlayerPrefs.SetInt("Vodka_Amount", amount + 1);
                break;

            case "Lithium":
                PlayerPrefs.SetString("Lithium", "True");
                amount = PlayerPrefs.GetInt("Lithium_Amount", 0);
                PlayerPrefs.SetInt("Lithium_Amount", amount + 1);
                break;

            case "Chute":
                PlayerPrefs.SetString("Chute", "True");
                break;
        }
        MoneyAmount.moneyAmount -= price;
    }
}
