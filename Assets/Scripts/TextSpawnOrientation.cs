using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawnOrientation : MonoBehaviour
{
    GameObject parent;

    private void Awake()
    {
        parent = transform.parent.gameObject;

        transform.localScale = parent.transform.localScale;
    }

    private void Update()
    {
        transform.localScale = parent.transform.localScale;
    }
}
