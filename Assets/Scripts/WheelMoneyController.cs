using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WheelMoneyController : MonoBehaviour
{
    public Text betText;
    string bet;
    public static bool notEnough;

    string slotDiv;
    string slotColor;
    public static bool mystery;
    int slotNumber;

    public Text selectionText;
    string selection;

    int selectionNumber;
    string selectDiv;
    string selectColor;
    public static bool winner;

    public TextMeshProUGUI winnerText;
    public Text prizeText;

    public Text outcomeText;

    public static float prizeAmount;
    float prizeMulti;
    public static bool spinOver;

    public GameObject dropdown;
    public string[] bets;

    public static bool calculated;
    //public static bool decideFate;

    public GameObject startBlocker;

    //Mystery Screen
    



    private void Awake()
    {
        winner = false;
        notEnough = false;
        calculated = false;
        spinOver = false;
        //decideFate = false;
    }

    private void Update()
    {
        
        bet = betText.text;
        selection = selectionText.text;
        if(BetAmount(bet) > MoneyAmount.moneyAmount)
        {
            startBlocker.SetActive(true);
        }
        else
        {
            startBlocker.SetActive(false);
        }
        SelectionInfo(selection);
        SlotProperties(SlotSelector.slot);
        SpinResult();
        SetWinnerText();
        Debug.Log("PrizeAmount: " + prizeAmount);
        //Debug.Log("Mathed: " + matched);
        //Debug.Log("Even: " + even);
        //Debug.Log("Odd: " + odd);
        //Debug.Log("Pink: " + pink);
        //Debug.Log("blue: " + blue);
        //Debug.Log("slotnumber: " + slotNumber);
        //Debug.Log("selection number: " + selectionNumber);
    }

    int BetAmount(string bet)
    {
        switch (bet)
        {
            case "$2":
                return 2;
            case "$4":
                return 4;
            case "$6":
                return 6;
            case "$8":
                return 8;
            case null:
                return 0;
            default:
                return 0;
        }
    }

     public void SubtractBetAmount()
    {
        if(notEnough != true)
        {
            MoneyAmount.moneyAmount -= BetAmount(bet);
        }
    }

    void SetBetRules()
    {
        if(notEnough == true)
        {
            
        }
    }

    void SlotProperties(string name)
    {
        switch (name)
        {
            case "0":
                slotColor = "blue";
                slotDiv = "even";
                slotNumber = 0;
                mystery = false;
                break;
            case "1":
                slotColor = "pink";
                slotDiv = "odd";
                slotNumber = 1;
                mystery = false;
                break;
            case "2":
                slotColor = "blue";
                slotDiv = "even";
                slotNumber = 2;
                mystery = false;
                break;
            case "3":
                slotColor = "blue";
                slotDiv = "odd";
                slotNumber = 3;
                mystery = false;
                break;
            case "4":
                slotColor = "pink";
                slotDiv = "even";
                slotNumber = 4;
                mystery = false;
                break;
            case "6":
                slotColor = "blue";
                slotDiv = "even";
                slotNumber = 6;
                mystery = false;
                break;
            case "7":
                slotColor = "pink";
                slotDiv = "odd";
                slotNumber = 7;
                mystery = false;
                break;
            case "8":
                slotColor = "pink";
                slotDiv = "even";
                slotNumber = 8;
                mystery = false;
                break;
            case "9":
                slotColor = "blue";
                slotDiv = "odd";
                slotNumber = 9;
                mystery = false;
                break;
            case "10":
                slotColor = "blue";
                slotDiv = "even";
                slotNumber = 10;
                mystery = false;
                break;
            case "11":
                slotColor = "pink";
                slotDiv = "odd";
                slotNumber = 11;
                mystery = false;
                break;
            case "12":
                slotColor = "blue";
                slotDiv = "even";
                slotNumber = 12;
                mystery = false;
                break;
            case "14":
                slotColor = "pink";
                slotDiv = "even";
                slotNumber = 14;
                mystery = false;
                break;
            case "?":
                slotColor = "none";
                slotDiv = "none";
                slotNumber = -1;
                mystery = true;
                break;
            case "loser":
                slotColor = "none";
                slotDiv = "none";
                slotNumber = -1;
                mystery = false;
                break;

            default:
                break;
        }
    }

    void SelectionInfo(string selection)
    {
        switch (selection)
        {
            case "EVEN":
                selectDiv = "even";
                selectionNumber = -2;
                selectColor = "notSelected";
                prizeMulti = 2f;
                break;
            case "ODD":
                selectDiv = "odd";
                selectColor = "notSelected";
                selectionNumber = -2;
                prizeMulti = 5f;
                break;
            case "PINK":
                selectColor = "pink";
                selectDiv = "notSelected";
                selectionNumber = -2;
                prizeMulti = 4f;
                break;
            case "BLUE":
                selectColor = "blue";
                selectDiv = "notSelected";
                selectionNumber = -2;
                prizeMulti = 3f;
                break;
            case "1":
                selectionNumber = 1;
                selectDiv = "notSelected";
                selectColor = "notSelected";
                prizeMulti = 10f;

                break;
            case "2":
                selectionNumber = 2;
                selectDiv = "notSelected";
                selectColor = "notSelected";
                prizeMulti = 10f;
                break;
            case "3":
                selectionNumber = 3;
                selectDiv = "notSelected";
                selectColor = "notSelected";
                prizeMulti = 10f;
                break;
            case "4":
                selectionNumber = 4;
                selectDiv = "notSelected";
                selectColor = "notSelected";
                prizeMulti = 10f;
                break;
            case "0":
                selectionNumber = 0;
                selectDiv = "notSelected";
                selectColor = "notSelected";
                prizeMulti = 10f;
                break;
            case "6":
                selectionNumber = 6;
                selectDiv = "notSelected";
                selectColor = "notSelected";
                prizeMulti = 10f;
                break;
            case "7":
                selectionNumber = 7;
                selectDiv = "notSelected";
                selectColor = "notSelected";
                prizeMulti = 10f;
                break;
            case "8":
                selectionNumber = 8;
                selectDiv = "notSelected";
                selectColor = "notSelected";
                prizeMulti = 10f;
                break;
            case "9":
                selectionNumber = 9;
                selectDiv = "notSelected";
                selectColor = "notSelected";
                prizeMulti = 10f;
                break;
            case "10":
                selectionNumber = 10;
                selectDiv = "notSelected";
                selectColor = "notSelected";
                prizeMulti = 10f;
                break;
            case "11":
                selectionNumber = 11;
                selectDiv = "notSelected";
                selectColor = "notSelected";
                prizeMulti = 10f;
                break;
            case "12":
                selectionNumber = 12;
                selectDiv = "notSelected";
                selectColor = "notSelected";
                prizeMulti = 10f;
                break;
            case "14":
                selectionNumber = 14;
                selectDiv = "notSelected";
                selectColor = "notSelected";
                prizeMulti = 10f;
                break;
        }
    }

    void SpinResult()
    {
        if(slotNumber == selectionNumber ||  selectDiv == slotDiv || selectColor == slotColor)
        {
            winner = true;
        }
        else
        {
            winner = false;
        }
    }

    void CalculateWinnings()
    {
        if(calculated == false)
        {
            prizeAmount = prizeMulti * BetAmount(bet);
        }
    }

    void SetWinnerText()
    {
        if(spinOver == false)
        {
            if (winner == true && mystery == false)
            {
                winnerText.text = "Winner!";
                outcomeText.text = SlotSelector.slot;
                CalculateWinnings();
                prizeText.text = "+$" + prizeAmount;
                
            }
            else if(winner == false && mystery == false)
            {
                winnerText.text = "Loser";
                outcomeText.text = SlotSelector.slot;
                prizeText.text = "Better Luck Next Time...";
                
            }
            
        }
    }
    //Mystery
    
  
}
