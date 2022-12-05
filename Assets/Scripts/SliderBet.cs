using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBet : MonoBehaviour
{
    public GameObject betSlider;
    Slider slider;
    public static int betAmount;

    public Text betText;

    private void Awake()
    {
        slider = betSlider.GetComponent<Slider>();
    }

    private void Start()
    {
        slider.value = betAmount;
    }

    private void Update()
    {
        betText.text = slider.value.ToString();
        betAmount = (int)slider.value;
    }

    public void ToggleSlider()
    {
        if (!betSlider.activeInHierarchy)
        {
            betSlider.SetActive(true);
        }
        else
        {
            betSlider.SetActive(false);

        }
    }
}
