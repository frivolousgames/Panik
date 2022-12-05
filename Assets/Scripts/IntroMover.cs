using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMover : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void MoveStuff()
    {
        anim.SetTrigger("Clicked");
    }
}
