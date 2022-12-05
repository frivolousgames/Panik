using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchParentScaleX : MonoBehaviour
{
    private void OnEnable()
    {
        if (transform.parent != null)
        {
            if(transform.parent.localScale.x < 0)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
            
        }
    }
}
