using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAnimation : MonoBehaviour
{
    
    Animator anim;

    public static bool paused = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if(paused == false)
        {
            anim.speed = 1;
        }
        else
        {
            anim.speed = 0;
        }
        

        /*if(paused == false)
        {
            anim["Walk"].enabled = false;
        }
        else
        {
            anim["Walk"].enabled = true;

        }*/
    }
}
