using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InvokeCamShake : MonoBehaviour
{
    public GameObject shakeCam;
    public float shakeTime;

    float defaultBlendTime;

    public CinemachineBrain brain;

    private void Awake()
    {
        defaultBlendTime = brain.m_DefaultBlend.m_Time;
    }

    public void SetCamerActive()
    {
        brain.m_DefaultBlend.m_Time = 0f;
       
        shakeCam.SetActive(true);
        StartCoroutine("DeactivateCam");
    }

    IEnumerator DeactivateCam()
    {
        yield return new WaitForSeconds(shakeTime);
        shakeCam.SetActive(false);
        StartCoroutine(ResetBlendTime());
    }

    IEnumerator ResetBlendTime()
    {
        yield return new WaitForSeconds(.5f);
        brain.m_DefaultBlend.m_Time = defaultBlendTime;
    }
}
