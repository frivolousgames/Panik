using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillagerManCasinoController : MonoBehaviour
{
    //MonoBehaviour enterButtonScript;

    public GameObject babushkaButton;
    public GameObject circleButton;

    public GameObject casinoButton;
    public GameObject exitButton;

    public Text talkText;

    private void Awake()
    {
        casinoButton.SetActive(false);
        //enterButtonScript = GetComponent<TriggerEnterButton>();
    }

    private void Update()
    {
        CheckCasino();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            GameController.chipUsable = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            GameController.chipUsable = false;
        }
    }
    
    public void AcceptChip()
    {
        if (PlayerPrefs.GetString("Chip Completed", "False") == "False" && GameController.chipUsed == true)
        {
            PlayerPrefs.SetString("Chip Completed", "True");
            babushkaButton.SetActive(true);
            circleButton.SetActive(true);
            casinoButton.SetActive(false);
            talkText.text = "Choose Your Game:\n\n\n";
            exitButton.SetActive(true);
           
            
        }  
    }

    void CheckCasino()
    {
        if(PlayerPrefs.GetString("Chip Completed", "False") == "True")
        {
            babushkaButton.SetActive(true);
            circleButton.SetActive(true);
            casinoButton.SetActive(false);
            talkText.text = "Choose Your Game:\n\n\n";
            exitButton.SetActive(true);
        }
    }

    public void SetCasinoButtonActive()
    {
        if(GameController.chipUsed == true)
        {
            if (PlayerPrefs.GetString("Chip Completed", "False") == "False")
            {
                casinoButton.SetActive(true);
                exitButton.SetActive(false);
            }
            else
        {
                casinoButton.SetActive(false);
                exitButton.SetActive(true);
            }
        } 
    }
}
