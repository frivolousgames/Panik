using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitColor : MonoBehaviour
{
    SpriteRenderer sr;
    Color original;

    private void OnEnable()
    {
        StartCoroutine("SetColorBack");
    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        original = sr.color;
    }

    public void HitColorChange()
    {
        if(gameObject.activeInHierarchy == true)
        {
            sr.color = new Color32(255, 100, 100, 255);
            StartCoroutine("SetColorBack");
        } 
    }

    IEnumerator SetColorBack()
    {
        yield return new WaitForSeconds(.1f);
        sr.color = original;
    }
}
