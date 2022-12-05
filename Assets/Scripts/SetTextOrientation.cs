using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTextOrientation : MonoBehaviour
{

    GameObject parent;
    Vector2 startScale;

    private void Awake()
    {
        startScale = transform.localScale;
        
        parent = transform.parent.gameObject;
        if (parent.transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(-startScale.x, startScale.y);
        }
        else
        {
            transform.localScale = startScale;
        }
    }

    private void Update()
    {
        if(parent.transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(-startScale.x, startScale.y);
        }
        else
        {
            transform.localScale = startScale;
        }
        Debug.Log(parent.gameObject);
    }
}
