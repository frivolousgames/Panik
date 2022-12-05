using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInNextBubble : MonoBehaviour
{
    public GameObject bubble;
    public float waitTime;

    private void Awake()
    {
        //StartCoroutine("BubbleWait");
    }

    IEnumerator BubbleWait()
    {
        yield return new WaitForSeconds(waitTime);
        //bubble.SetActive(true);
    }
}
