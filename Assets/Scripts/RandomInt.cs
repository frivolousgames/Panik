using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInt : MonoBehaviour
{
    public int min;
    public int max;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void GetRandom()
    {
        anim.SetInteger("Random", Random.Range(min, max));
    }
}
