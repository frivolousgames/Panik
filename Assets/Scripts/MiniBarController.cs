using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniBarController : MonoBehaviour
{
    float max;
    float amount;
    public float rate;
    public Slider barSlider;

    private void Update()
    {
        SetBarInfo(gameObject.name);
        barSlider.value = amount;
        Debug.Log(amount);
    }

    void SetBarInfo(string barName)
    {
        switch (barName)
        {
            case "FireBar":
                max = GameController.flameMax;
                amount = GameController.flameAmount;
                break;
        }
    }

    public void SubtractAmount(string barName)
    {
        if (gameObject.activeInHierarchy)
        {
            if(PlayerController.isShooting == true)
            {
                if(amount > 0)
                {
                    amount -= rate * Time.deltaTime;
                }
            }
        }
    }
}
