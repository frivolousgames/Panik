using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBuySlots : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject[] buys;

    

    private void Update()
    {
        foreach(GameObject button in buttons)
        {
            if (int.Parse(button.GetComponentInChildren<Text>().text.ToString()) < MoneyAmount.moneyAmount)
            {
                button.GetComponent<Button>().interactable = true;
                foreach(GameObject buy in buys)
                {
                    if(buy.name == "Buy " + button.name)
                    {
                        buy.SetActive(true);
                    }
                }
            }
            
        }
    }

    public void Blurb()
    {

    }



}
