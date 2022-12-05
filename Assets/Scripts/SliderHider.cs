using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHider : MonoBehaviour
{
    public GameObject betSlider;

    public void HideSlider()
    {
        betSlider.SetActive(false);
    }
}
