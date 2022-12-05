using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FreezeController : MonoBehaviour
{
    public UnityEvent freeze;
    public UnityEvent unFreeze;
    public float time;
    public GameObject blocker;

    private void Start()
    {
        freeze.Invoke();
        blocker.SetActive(true);
        StartCoroutine("UnFreeze");
    }

    IEnumerator UnFreeze()
    {
        yield return new WaitForSeconds(time);
        blocker.SetActive(false);
        unFreeze.Invoke();
    }
}
