using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBlinkActive : MonoBehaviour
{
    public GameObject blinker;

    public void SetBlinkerActive()
    {
        blinker.SetActive(true);
    }
}
