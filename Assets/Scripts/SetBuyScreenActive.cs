using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetBuyScreenActive : MonoBehaviour
{
    public GameObject buyScreen;

    public void ActivateScreen()
    {
        //buyScreen.SetActive(true);
        SceneManager.LoadScene("Buy_Screen_01_Rock");
    }
    
}
