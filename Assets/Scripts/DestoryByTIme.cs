using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByTIme : MonoBehaviour
{
    public float waitTime;

    private void Awake()
    {
        StartCoroutine("DestroyWait");
    }

    IEnumerator DestroyWait()
    {
        
        yield return new WaitForSeconds(waitTime);
        if (GameController.freezeAll != true)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine("DestroyWait");

        }

    }
    

    public void SetWaitTime()
    {
        
    }
}
