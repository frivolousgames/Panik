using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour
{
    Animator anim;
    AnimatorStateInfo animInfo;

    public GameObject duck;
    Rigidbody2D rb;
    public float walkSpeed;
    bool isWalking;

    int int1;
    int int2;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        
        rb = duck.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
        Walk();
        IsWalking();
        //Debug.Log("Walking " + isWalking);
        //Debug.Log(animInfo.shortNameHash);
    }

    void Walk()
    {
        if(isWalking == true)
        {
            if (duck.transform.localScale.x < 1f)
            {
                rb.velocity = new Vector2(walkSpeed, 0f);
            }
            else
            {
                rb.velocity = new Vector2(-walkSpeed, 0f);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }

    void IsWalking()
    {
        if(animInfo.shortNameHash == Animator.StringToHash("Walk"))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }

    

    public void RandomInt()
    {
        int1 = Random.Range(0, 2);
        int2 = Random.Range(0, 2);
        anim.SetInteger("Int01", int1);
        anim.SetInteger("Int02", int2);
    }
   
}
