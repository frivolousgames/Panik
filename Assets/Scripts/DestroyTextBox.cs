using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyTextBox : MonoBehaviour
{
    
    public Animator anim;
    public static UnityEvent closeBox;

    public void CloseBox()
    {
        anim.SetTrigger("close");
    }
    
}
