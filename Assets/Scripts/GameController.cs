using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gameManager;

    //SceneManagement
    public static Vector2 returnToAreaPosition;
    public static float returnToAreaXScale;

    //Player
    GameObject player;
    //Animator playerAnim;
    //Rigidbody2D playerRb;

    //Guns

    public static string equippedGun;
    public static bool hasGunEquipped;
    public static bool hasGun;

    //Ammo

    public static float flameAmount;
    public static float flameMax;
    float fReplenRate;
    //Chute


    //Items
    public static bool hasHat = false;
    public static bool hasChip = false;
    public static bool hasChute = false;
    public static bool hasBalloon = false;
    public static bool hasBattery = false;

    public static bool hasDynamite = false;
    public static int dynamiteAmount;
    public static bool dynamiteFull = false;


    public static bool hasVodka = false;
    public static int vodkaAmount;
    public static bool vodkaFull = false;

    public static bool hasLithium = false;
    public static int lithiumAmount;
    public static bool lithiumFull = false;

    public static bool hasBazooka = false;
    public static bool hasFlamethrower = false;
    public static bool hasDefaultGun = false;

    public static bool flamethrower;
    public static bool bazooka;
    public static bool defaultGun;

    

    //GameObject hatIcon;

    //BuyScreen
    public static string slot01;
    public static string slot02;
    public static string slot03;

    //Scene Management
    public static string currentScene;
    public static string saneLevel;

    //Insanity Timer
    //public float insanityStartTime;
    //public static float insanityTime;

    //Current Scene Info
    Slider sanitySlider;
    public static float sanityAmount;

    Slider lifeSlider;
    public static float lifeAmount;

    public static string equippedWeapon;
    public static int money;
    

    public static bool freezeAll;

    //Inventory
    public static string inventoryObjectName;

    public static bool hatUsable;
    public static bool chipUsable;
    public static bool batteryUsable;
    public static bool vodkaUsable;
    public static bool lithiumUsable;
    public static bool balloonUsable;
    public static bool dynamiteUsable;

    public static bool hatUsed;
    public static bool chipUsed;
    public static bool batteryUsed;
    public static bool dynamiteUsed;


    public static bool sellable;

    public static string inventoryObjectSelection;

    //Special Moves

    
    //Race
    
    //Halliphone
    

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        //Item Setting Debug//

        PlayerPrefs.SetString("Chute", "True");
        //PlayerPrefs.SetInt("Vodka_Amount", 3);
        //PlayerPrefs.SetString("Vodka", "True");
        //PlayerPrefs.SetString("Lithium", "False");
        //PlayerPrefs.SetInt("Lithium_Amount", 0);
        PlayerPrefs.SetString("Flamethrower", "True");
        PlayerPrefs.SetString("DefaultGun", "True");
        PlayerPrefs.SetString("Bazooka", "True");
        PlayerPrefs.SetString("Hat", "False");
        PlayerPrefs.SetString("HatCompleted", "False");
        PlayerPrefs.SetString("Chip", "True");
        PlayerPrefs.SetString("Chip Completed", "False");
        PlayerPrefs.SetString("Balloon", "True");
        PlayerPrefs.SetString("Battery", "True");

        PlayerPrefs.SetString("Dash", "True");
        //PlayerPrefs.SetString("Energy", "True");

        PlayerPrefs.SetString("Halluciphone_Started", "False");
        PlayerPrefs.SetString("Halluciphone_Awake", "False");

        //SceneManagement

        //Items

        //returnToAreaPosition = Vector2.down;
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerAnim = player.GetComponentInChildren<Animator>();
        //playerRb = player.GetComponent<Rigidbody2D>();

        //insanityTime = insanityStartTime;


    }
        private void Update()
    {
        //Items
        HasHat();
        HasChip();
        HasBattery();
        HasChute();
        HasBalloon();
        HasDynamite();

        HasVodka();
        VodkaAmount();

        LithiumAmount();
        HasLithium();
        DynamiteAmount();

        //Guns
        HasDefaultGun();
        HasBazooka();
        HasFlamethrower();

        HasGun();
        SetGunBool(equippedGun);

        //Ammo
        FlameAmount();
        ReplenishFlameAmount();
        //hatIcon = GameObject.FindGameObjectWithTag("HatIcon");

        //Current Scene Info
        GetEquippedWeapon();
        GetSanityMeter();
        GetSanityLevel();
        GetLifeMeter();
        GetLifeLevel();
        
        //BuyScreen
        GetBuyScreenScene();

        //Scene Management
        GetCurrentScene();

        //Special Moves
        HasDash();

        //Debug.Log("Has Battery " + hasBattery);
        //Debug.Log("Equipped Gun " + equippedGun);
        //Debug.Log("Vodka " + hasVodka);
        //Debug.Log("V Amount " + PlayerPrefs.GetInt("Vodka_Amount", 0));

        //Freeze

    }

    //Game Start
    public static bool ContinueCheck()
    {
        if (PlayerPrefs.GetInt("Level", 0) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    //Chute

    //Player

    //Guns

    void HasGun()
    {
        if(hasBazooka != true &&
           hasFlamethrower != true &&
           hasDefaultGun != true)
        {
            hasGun = false; 
        }
        else
        {
            hasGun = true;
        }
    }

    void SetGunBool(string name)
    {
        switch (name)
        {
            case "FlameThrower":
                flamethrower = true;
                bazooka = false;
                defaultGun = false;
                break;
            case "Bazooka":
                bazooka = true;
                flamethrower = false;
                defaultGun = false;
                break;
            case "Default_gun":
                defaultGun = true;
                bazooka = false;
                flamethrower = false;
                break;
            case null:
                break;
        }
    }

    //Ammo

    void FlameAmount()
    {
        //flameAmount = PlayerPrefs.GetFloat("FlameAmount", 10);
        flameMax = PlayerPrefs.GetFloat("FlameMax", 10);
        fReplenRate = PlayerPrefs.GetFloat("FlameRate", .2f);
    }



    void ReplenishFlameAmount()
    {
        if(PlayerController.isShooting == false)
        {
            if(flameAmount < flameMax)
            {
                PlayerPrefs.SetFloat("FlameAmount", flameAmount + (fReplenRate * Time.deltaTime));
            }
            
        }
    }

    //Items
    void HasHat()
    {
        if(PlayerPrefs.GetString("Hat", "False") == "True")
        {
            hasHat = true;
        }
        else
        {
            hasHat = false;
        }
    }
    void HasChip()
    {
        if (PlayerPrefs.GetString("Chip", "False") == "True")
        {
            hasChip = true;
        }
        else
        {
            hasChip = false;
        }
    }
    void HasBattery()
    {
        if (PlayerPrefs.GetString("Battery", "False") == "True")
        {
            hasBattery = true;
        }
        else
        {
            hasBattery = false;
        }
    }
    void HasChute()
    {
        if(PlayerPrefs.GetString("Chute", "False") == "True")
        {
            hasChute = true;
        }
        else
        {
            hasChute = false; 
        }
    }
    void HasBalloon()
    {
        if (PlayerPrefs.GetString("Balloon", "False") == "True")
        {
            hasBalloon = true;
        }
        else
        {
            hasBalloon = false;
        }
    }
    void HasDynamite()
    {
        if (PlayerPrefs.GetString("Dynamite", "False") == "True")
        {
            hasDynamite = true;
        }
        else
        {
            hasDynamite = false;
        }
    }
    void DynamiteAmount()
    {
        dynamiteAmount = PlayerPrefs.GetInt("Dynamite_Amount", 0);
        if (dynamiteAmount > 2)
        {
            dynamiteFull = true;
        }
        else if (dynamiteAmount < 1)
        {
            PlayerPrefs.SetString("Dynamite", "False");
        }
        else
        {
            dynamiteFull = false;
        }
    }
    void HasDefaultGun()
    {
        if (PlayerPrefs.GetString("DefaultGun", "False") == "True")
        {
            hasDefaultGun = true;
        }
        else
        {
            hasDefaultGun = false;
        }
    }
    void HasBazooka()
    {
        if (PlayerPrefs.GetString("Bazooka", "False") == "True")
        {
            hasBazooka = true;
        }
        else
        {
            hasBazooka = false;
        }
    }
    void HasFlamethrower()
    {
        if (PlayerPrefs.GetString("Flamethrower", "False") == "True")
        {
            hasFlamethrower = true;
        }
        else
        {
            hasFlamethrower = false;
        }
    }
    void HasVodka()
    {
        if (PlayerPrefs.GetString("Vodka", "False") == "True" && PlayerPrefs.GetInt("Vodka_Amount", 0) > 0)
        {
            hasVodka = true;
        }
        else
        {
            hasVodka = false;
        }
    }
    void VodkaAmount()
    {
        vodkaAmount = PlayerPrefs.GetInt("Vodka_Amount", 0);
        if (vodkaAmount > 2)
        {
            vodkaFull = true;
        }
        
        else
        {
            vodkaFull = false;
        }
    }
    void HasLithium()
    {
        if (PlayerPrefs.GetString("Lithium", "False") == "True" && PlayerPrefs.GetInt("Lithium_Amount", 0) > 0)
        {
            hasLithium = true;
        }
        else
        {
            hasLithium = false;
        }
    }
    void LithiumAmount()
    {
        lithiumAmount = PlayerPrefs.GetInt("Lithium_Amount", 0);
        if(lithiumAmount > 2)
        {
            lithiumFull = true;
        }
        else if (lithiumAmount < 1)
        {
            PlayerPrefs.SetString("Lithium", "False");
        }
        else
        {
            lithiumFull = false;
        }
    }
    //BuyScreen

    void GetBuyScreenScene()
    {
        if(currentScene == "Buy_Screen_01_Rock")
        {
            slot01 = "Vodka";
            slot02 = "Lithium";
            slot03 = "Chute";
        }
    }

    //Scene Management
    void GetCurrentScene()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    //Current Scene Info

    void GetEquippedWeapon()
    {
        if (GameObject.FindGameObjectWithTag("Gun") != null)
        {
            equippedWeapon = GameObject.FindGameObjectWithTag("Gun").ToString();
        }
    }

    void GetSanityMeter()
    {
        if(GameObject.FindGameObjectWithTag("SanityMeter") != null)
        {
            sanitySlider = GameObject.FindGameObjectWithTag("SanityMeter").GetComponent<Slider>();
        }
    }

    void GetSanityLevel()
    {
        if(sanitySlider != null)
        {
            sanityAmount = sanitySlider.value;
        }
    }

    void GetLifeMeter()
    {
        if (GameObject.FindGameObjectWithTag("PlayerLifeMeter") != null)
        {
            lifeSlider = GameObject.FindGameObjectWithTag("PlayerLifeMeter").GetComponent<Slider>();
        }
    }

    void GetLifeLevel()
    {
        if (lifeSlider != null)
        {
            lifeAmount = lifeSlider.value;
        }
    }
    //Inventory

    public static bool VodkaUsable()
    {
        if(hasVodka != false && PlayerHealth.health < 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool LithiumUsable()
    {
        if (hasLithium != false /* && villageTime != true*/)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Special Moves
    /*public static bool SetSpecial()
    {
        
    }*/
    public static bool HasDash()
    {
        if(PlayerPrefs.GetString("Dash", "False") == "True")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool HasEnergy()
    {
        if (PlayerPrefs.GetString("Energy", "False") == "True")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
