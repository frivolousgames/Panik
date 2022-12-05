using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalluciphoneController : MonoBehaviour
{
    Animator anim;
    AnimatorStateInfo animInfo;

    bool awake;
    public static bool started;
    bool working;
    bool startingUp;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        IsStarted();
        IsAwake();

        animInfo = anim.GetCurrentAnimatorStateInfo(0);

        anim.SetBool("Awake", awake);
        anim.SetBool("Started", started);
        anim.SetBool("Working", working);


    }

    void IsStarted()
    {
        if(PlayerPrefs.GetString("Halluciphone_Started", "False") == "True")
        {
            started = true;
        }
        else
        {
            started = false;
        }
    }
    void IsAwake()
    {
        if (PlayerPrefs.GetString("Halluciphone_Awake", "False") == "True")
        {
            awake = true;
        }
        else
        {
            awake = false;
        }
    }
    
    public void WakeUp()
    {    
        PlayerController.isFrozen = true;
    }
    public void Started()
    {
        PlayerPrefs.SetString("Halluciphone_Started", "True");
        PlayerController.isFrozen = false;
    }
}
