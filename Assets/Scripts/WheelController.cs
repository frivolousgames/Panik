using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelController : MonoBehaviour
{
    Rigidbody2D rb;
    float power;
    public float speed;

    public float meterAmount;
    bool isHoldingSpin;
    public int holdPower;

    public Slider meter;

    public static bool spinOver;
    public static bool spinDisabled;
    public static bool isSpinning;

    public GameObject winScreen;

    bool betSubtracted;

    bool added;

    public Text prizeText;

    public GameObject screenBlocker;

    //Mystery
    public GameObject mysteryWinScreen;
    public TextMeshProUGUI mysteryPrizeText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spinOver = false;
        if (MoneyAmount.moneyAmount > 1)
        {
            spinDisabled = false;
        }
        else
        {
            spinDisabled = true;
        }
        isSpinning = false;
    }

    private void FixedUpdate()
    {
        rb.rotation += power;
        if (power > .08f)
        {
            rb.isKinematic = true;
            power = Mathf.Lerp(power, 0, Time.deltaTime * speed);
            isSpinning = true;
        }
        else
        {
            if (spinDisabled != false)
            {
                rb.isKinematic = false;
            }
            //power = 0;
        }

    }

    private void Update()
    {
        
        if(betSubtracted)
        {
            spinDisabled = true;
        }
        meter.value = meterAmount;
        if(isHoldingSpin != false)
        {
            //meterAmount = Mathf.PingPong(Time.time *10, holdPower);
            meterAmount = Mathf.PingPong(Time.time * 50, holdPower);
            
        }
        //spinOver = true;
        if (spinDisabled == true && rb.isKinematic != true)
        {
            if (rb.angularVelocity < .02f)
            {
                spinOver = true;
                power = 0f;
                rb.angularVelocity = 0;
                rb.isKinematic = true;
                if(isSpinning != false)
                {
                    StartCoroutine("WinPause");
                    WheelMoneyController.calculated = true;
                }
            }
        }
        //Debug.Log("Winnstuff: " + WheelMoneyController.prizeAmount * Time.deltaTime);
        //Debug.Log("Is Spinning: " + isSpinning);
        //Debug.Log("Spun: " + spun);
    }

    IEnumerator WinPause()
    {
        isSpinning = false;
        yield return new WaitForSeconds(1.4f);
        screenBlocker.SetActive(false);
        betSubtracted = false;
        if(WheelMoneyController.mystery == true)
        {
            mysteryWinScreen.SetActive(true);
        }
        else
        {
            winScreen.SetActive(true);

        }
    }

    public void Finish()
    {
        if (WheelMoneyController.winner == true && WheelMoneyController.mystery != true)
        {
            StartCoroutine("AddMoney");
        }
        else if(WheelMoneyController.winner != true && WheelMoneyController.mystery != true)
        {
            spinOver = false;
            isSpinning = false;
            spinDisabled = false;
            winScreen.SetActive(false);
            WheelMoneyController.calculated = false;
            WheelMoneyController.spinOver = false;
        }
        else if(WheelMoneyController.winner != true && WheelMoneyController.mystery == true)
        {
            winScreen.SetActive(false);
            mysteryWinScreen.SetActive(true);
        }
    }
    public void CloseMysteryScreen()
    {
        Debug.Log(MysteryScreenController.mysteryPrize);
        switch (MysteryScreenController.mysteryPrize)
        {
            case "MoneySack":
                StartCoroutine("AddMysteryMoney");
                break;
            case "Gem":
                StartCoroutine("AddMysteryMoney");
                break;
            case "Helga":
                MysteryReset();
                break;
            case "Vodka":
                if(GameController.vodkaFull != true)
                {
                    int amount = PlayerPrefs.GetInt("Vodka_Amount", 0);
                    PlayerPrefs.SetInt("Vodka_Amount", amount + 1);
                }
                else
                {
                    Debug.Log("Vodka is Full");
                }
                MysteryReset();
                break;
            case "Dash":
                PlayerPrefs.SetString("Dash", "True");
                MysteryReset();
                break;
            default:
                Debug.LogError("No String Selected!");
                break; 
        }
            

    }
    void MysteryReset()
    {
        mysteryWinScreen.SetActive(false);
        spinOver = false;
        isSpinning = false;
        spinDisabled = false;
        WheelMoneyController.calculated = false;
        WheelMoneyController.spinOver = false;
    }

    IEnumerator AddMysteryMoney()
    {
        WheelMoneyController.spinOver = true;
        while (WheelMoneyController.prizeAmount > 0)
        {
            MoneyAmount.moneyAmount++;
            WheelMoneyController.prizeAmount--;
            mysteryPrizeText.text = "+$" + WheelMoneyController.prizeAmount.ToString();
            yield return new WaitForSeconds(.05f);
        }
        yield return new WaitForSeconds(.8f);
        mysteryWinScreen.SetActive(false);
        spinOver = false;
        isSpinning = false;
        spinDisabled = false;
        WheelMoneyController.calculated = false;
        WheelMoneyController.spinOver = false;
    }

    IEnumerator AddMoney()
    {
        WheelMoneyController.spinOver = true;
        while (WheelMoneyController.prizeAmount > 0)
        {
            MoneyAmount.moneyAmount ++;
            WheelMoneyController.prizeAmount--;
            prizeText.text = "+$" + WheelMoneyController.prizeAmount.ToString();
            yield return new WaitForSeconds(.05f);
        }
        yield return new WaitForSeconds(.8f);
        spinOver = false;
        isSpinning = false;
        spinDisabled = false;
        winScreen.SetActive(false);
        WheelMoneyController.calculated = false;
        WheelMoneyController.spinOver = false;

        //float prize = WheelMoneyController.prizeAmount * Time.deltaTime;

        //WheelMoneyController.prizeAmount -= 1 * Time.deltaTime;
    }

    public void BuildMeter()
    {
        if (spinDisabled != true)
        {
            
            isHoldingSpin = true;
        }     
    }

    public void Spin()
    {
        if (spinDisabled != true)
        {
            isHoldingSpin = false;
            if (meterAmount < 3)
            {
                power = meterAmount + 5;
            }
            else
            {
                power = meterAmount;
            }
            spinOver = false;
            screenBlocker.SetActive(true);
            StartCoroutine("SpinWait");
        }       
    }

    public void Retry()
    {
        spinOver = false;
        isSpinning = false;
        spinDisabled = false;
        winScreen.SetActive(false);
    }

    IEnumerator SpinWait()
    {
        yield return new WaitForSeconds(.01f);
        spinDisabled = true;

    }
}
