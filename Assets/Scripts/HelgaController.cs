using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelgaController : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Reach()
    {
        if(WheelController.spinDisabled != true)
        {
            anim.SetTrigger("Reach");
        } 
    }

    public void Spin()
    {
        if (WheelController.spinDisabled != true)
        {
            anim.SetTrigger("Spin");

        }
    }


}
