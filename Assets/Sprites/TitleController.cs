using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    Animator anim;
    AnimatorStateInfo animInfo;
    bool shake;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        StartCoroutine("ShakeStarter");
    }

    private void Update()
    {
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
        anim.SetBool("shake", shake);
    }

    IEnumerator ShakeStarter()
    {
        float rand = Random.Range(1f, 4f);
        yield return new WaitForSeconds(rand);
        ShakeController();
    }

    void ShakeController()
    {
        if(animInfo.tagHash != Animator.StringToHash("Shaking"))
        {
            shake = true;
            StartCoroutine("StopShake");
        }
    }
    IEnumerator StopShake()
    {
        float rand = Random.Range(0.5f, 1f);
        yield return new WaitForSeconds(rand);
        shake = false;
        StartCoroutine("ShakeStarter");
    }
}
