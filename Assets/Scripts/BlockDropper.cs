using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDropper : MonoBehaviour
{
    GameObject player;
    public Animator anim;
    AnimatorStateInfo animInfo;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            if(animInfo.tagHash != Animator.StringToHash("Dropout") &&
               animInfo.tagHash != Animator.StringToHash("Reappear"))
            {
                anim.SetTrigger("Landed");
            }
        }
    }



}
