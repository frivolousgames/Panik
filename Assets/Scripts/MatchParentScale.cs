using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchParentScale : MonoBehaviour
{

    private void Update()
    {
        if(transform.parent != null)
        {
            transform.localScale = transform.parent.localScale;
        }
    }
}
