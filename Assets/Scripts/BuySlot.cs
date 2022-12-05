using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New_Buy_Slot", menuName = "Buy Slot")]

public class BuySlot : ScriptableObject
{
    public Sprite icon;
    public new Sprite name;

    public int price;
}
