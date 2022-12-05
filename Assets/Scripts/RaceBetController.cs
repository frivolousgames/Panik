using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceBetController : MonoBehaviour
{
    public Text selectionText;
    bool won;

    public Text winText;
    public static string selection;

    bool started;
    bool over;

    public GameObject winScreen;
    public Text winnerText;
    public Text winnerSign;

    public Text rewardText;
    int reward;
    Color rewardColor;

    public Slider betSlider;
    public GameObject screenBlocker;

    public GameObject startBlocker;
    bool calculating;

    private void Awake()
    {
        rewardColor = new Color(17f, 255f, 0f, 255f);
        calculating = false;
    }

    private void Start()
    {
        if(selection != null)
        {
            selectionText.text = selection;
        }
    }

    private void Update()
    {
        SetWinscreenActive();
        Debug.Log("Winner: " + RaceController.winner);
        Debug.Log("Selected: " + selectionText.text);
        NotEnoughMoney();
    }

    void DecideOutcome()
    {
        if(selectionText.text == RaceController.winner)
        {
            won = true;
        }
        else
        {
            won = false;
        }
    }

    void SetWinscreenActive()
    {
        if(RaceOver() == true)
        {
            DecideOutcome();
            screenBlocker.SetActive(false);
            if (won == true)
            {
                if(calculating == false)
                {
                    BetAmount();
                    rewardText.color = Color.green;
                    winnerText.text = "Winner!";
                    rewardText.text = "+$" + reward;
                }
            }
            else
            {
                rewardText.color = Color.cyan;
                rewardText.text = "Sorry Try Again";
                winnerText.text = "Loser";
            }
            
            winnerSign.text = RaceController.winner + " won";
            winScreen.SetActive(true);
        }
    }

    bool RaceOver()
    {
        if(started == true && RaceController.paused == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void StartRace()
    {
        if(RaceController.paused != false)
        {
            screenBlocker.SetActive(true);
            RaceController.paused = false;
            started = true;
            MoneyAmount.moneyAmount -= (int)betSlider.value;
        }
    }

    void BetAmount()
    {
        reward = (int)betSlider.value * 3;
    }

    public void CollectReward()
    {
        if(won == true)
        {
            if(started == true)
            {
                StartCoroutine("CollectMoney");
                started = false;
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    IEnumerator CollectMoney()
    {
        calculating = true;
        while(reward > 0)
        {
            MoneyAmount.moneyAmount++;
            reward--;
            rewardText.text = "+$" + reward;
            yield return new WaitForSeconds(.03f);
        }
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void InstantCollect()
    {
        if(calculating == true)
        {
            StopCoroutine("CollectMoney");
            MoneyAmount.moneyAmount += reward;
            rewardText.text = "$0" + reward;
            reward = 0;
        } 
    }

    void NotEnoughMoney()
    {
        if(betSlider.value > MoneyAmount.moneyAmount)
        {
            startBlocker.SetActive(true);
        }
        else
        {
            startBlocker.SetActive(false);

        }
    }
}
