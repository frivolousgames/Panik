using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFade : MonoBehaviour
{
    float waitTime;
    public SpriteRenderer sr;
    Color32 alpha;
    bool fade;

    private void Awake()
    {
        waitTime = GetComponent<DestoryByTIme>().waitTime;
    }

    private void Start()
    {
        StartCoroutine("FadeWait");
    }

    private void Update()
    {
        FadeOut();
    }

    IEnumerator FadeWait()
    {
        yield return new WaitForSeconds(waitTime - .1f);
        fade = true;
    }

    void FadeOut()
    {
        if (fade == true)
        {
            for (int i = 0; i > 255; i++)
            { 
                alpha = sr.color;
                alpha.a --;
                sr.color = alpha;
            }
            
        }
        
    }
}
