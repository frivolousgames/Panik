using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CowController : MonoBehaviour
{
    Animator anim;
    AnimatorStateInfo animInfo;
    //Transi animTr;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
    }

    private void Update()
    {
        if (animInfo.fullPathHash == Animator.StringToHash("Chew"))
        {
            
        }
    }

}
