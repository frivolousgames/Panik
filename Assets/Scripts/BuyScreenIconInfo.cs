using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyScreenIconInfo : MonoBehaviour
{
  //OBJECTS//

    //Vodka
    string vodkaSummaryText = "Restores a small amount of energy";
    string vodkaPrice = "20";
    public GameObject vodkaIcon;

    //Lithium
    string lithiumSummaryText = "Restores sanity instantly for a LIMITED TIME";
    string lithiumPrice = "50";
    public GameObject lithiumIcon;

    //Chute
    string chuteSummaryText = "HELPS YOU GLIDE THROUGH THE AIR WHEN FALLING";
    string chutePrice = "100";
    public GameObject chuteIcon;

    //SLOTS//
    Transform canvas;
    string slotName;
    

    //Slot Objects
    public GameObject iconNameObject;
    public GameObject priceObject;
    public Transform tipSpawn;
    int price;

    //ToolTip
    public GameObject tooltip;
    Text tipName;
    Text tipSummaryText;
    Text[] tipTexts;

    GameObject toolTipPrefab;

    //Buy Icons
    public GameObject buyIcon;
    public Transform buySpawnPos;

    GameObject buyIconPrefab;

    //Confirm Box
    public GameObject confirmBox;
    GameObject confirmBoxPrefab;
    public Transform confirmBoxSpawn;
    bool isFull;
    bool notForSale;

    private void Awake()
    {
        
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        confirmBox = GameObject.FindGameObjectWithTag("BuyConfirm");
        //SetIconInfo(slotName);
    }

    private void Start()
    {
        slotName = transform.GetComponent<Text>().text;
        SetIconInfo(slotName);
        
        if(confirmBox != null)
        {
            confirmBox.SetActive(false);
        }
    }

    private void Update()
    {
        SetBuyIcon();
        NotForSale();
        SetIsFull(slotName);
        Debug.Log("NotForSale " + notForSale);
        //SetIconInfo(slotName);
    }

    void SetIconInfo(string name)
    {
        switch (name)
        {
            case "Vodka":
                iconNameObject.GetComponent<Text>().text = "Vodka";
                priceObject.GetComponent<Text>().text = vodkaPrice;
                price = int.Parse(priceObject.GetComponent<Text>().text.ToString());
                Instantiate(vodkaIcon, gameObject.transform);

                buyIconPrefab = Instantiate(buyIcon, buySpawnPos.position, Quaternion.identity, canvas);
                SetBuyIcon();

                toolTipPrefab = Instantiate(tooltip, tipSpawn.position, Quaternion.identity, canvas);
                SetToolTipInfo();
                tipName.text = "Vodka";
                tipSummaryText.text = vodkaSummaryText;

                isFull = GameController.vodkaFull;
                
                break;

            case "Lithium":
                iconNameObject.GetComponent<Text>().text = "Lithium";
                priceObject.GetComponent<Text>().text = lithiumPrice;
                price = int.Parse(priceObject.GetComponent<Text>().text.ToString());

                Instantiate(lithiumIcon, gameObject.transform);

                buyIconPrefab = Instantiate(buyIcon, buySpawnPos.position, Quaternion.identity, canvas);
                SetBuyIcon();

                toolTipPrefab = Instantiate(tooltip, tipSpawn.position, Quaternion.identity, canvas);
                SetToolTipInfo();
                tipName.text = "Lithium";
                tipSummaryText.text = lithiumSummaryText;

                isFull = GameController.lithiumFull;

                break;

            case "Chute":
                iconNameObject.GetComponent<Text>().text = "Chute";
                priceObject.GetComponent<Text>().text = chutePrice;
                price = int.Parse(priceObject.GetComponent<Text>().text.ToString());

                Instantiate(chuteIcon, gameObject.transform);

                buyIconPrefab = Instantiate(buyIcon, buySpawnPos.position, Quaternion.identity, canvas);
                SetBuyIcon();

                toolTipPrefab = Instantiate(tooltip, tipSpawn.position, Quaternion.identity, canvas);
                SetToolTipInfo();
                tipName.text = "Chute";
                tipSummaryText.text = chuteSummaryText;

                isFull = GameController.hasChute;

                break;

            case null:
                iconNameObject.GetComponent<Text>().text = "Empty";
                break;

            default:
                break;
        }
    }

    void SetIsFull(string name)
    {
        switch (name)
        {
            case "Vodka":
                isFull = GameController.vodkaFull;
                break;
            case "Lithium":
                isFull = GameController.lithiumFull;
                break;
            case "Chute":
                isFull = GameController.hasChute;
                break;
        }
    }

    public void PopUp()
    {
        toolTipPrefab.SetActive(true);
    }

    public void Close()
    {
        toolTipPrefab.SetActive(false);
    }

    void SetToolTipInfo()
    {
        tipTexts = toolTipPrefab.GetComponentsInChildren<Text>();
        foreach (Text text in tipTexts)
        {
            if (text.gameObject.name == "Name")
            {
                tipName = text;
            }
            else
            {
                tipSummaryText = text;
            }
        }
    }

    void NotForSale()
    {
        if( price > MoneyAmount.moneyAmount || isFull != false)
        {
            notForSale = true;
        }
        
        else
        {
            notForSale = false;
        }
    }

    void SetBuyIcon()
    {
        
        if (notForSale != true)
        {
            gameObject.GetComponent<Button>().interactable = true;
            buyIconPrefab.SetActive(true);
        }      
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
            buyIconPrefab.SetActive(false);
        }
   }

    public void SpawnConfirmBox()
    {
        if(notForSale != true)
        {
            if(confirmBox.activeInHierarchy != true)
            {
                confirmBox.SetActive(true);
                confirmBox.transform.position = confirmBoxSpawn.position;
                ConfirmBoxController.buyName = slotName;
                ConfirmBoxController.price = price;
            }
        }
    }
}
