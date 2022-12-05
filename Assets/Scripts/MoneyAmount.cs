using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyAmount : MonoBehaviour
{
    Text moneyAmountText;
    public static int moneyAmount = 100;

    private void Awake()
    {
        moneyAmountText = GetComponent<Text>();
    }

    private void Update()
    {
        moneyAmountText.text = moneyAmount.ToString();
    }

}
