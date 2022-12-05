using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinButton : MonoBehaviour
{
    Button spinButton;

    private void Awake()
    {
        spinButton = GetComponent<Button>();
    }

    private void Update()
    {

        if(WheelController.spinDisabled != false)
        {
            spinButton.interactable = false;
        }
        else
        {
            spinButton.interactable = true;
        }
    }
}
