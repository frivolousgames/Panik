using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayClickStuff : MonoBehaviour
{
    public GameObject blinker;
    public GameObject blackScreenFader;
    public GameObject screenFadeOut;

    public void PlayClicked()
    {
        blinker.SetActive(true);
        blackScreenFader.SetActive(true);
        screenFadeOut.SetActive(true);
    }    
}
