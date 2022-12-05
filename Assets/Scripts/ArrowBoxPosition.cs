using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowBoxPosition : MonoBehaviour
{
    public GameObject text;

    Vector3 startRect;
    Vector3 textStartRect;
    Vector3 distance;

    RectTransform textRect;

    float textCenter;

    public float offset;

    private void Awake()
    {
        textRect = text.GetComponent<RectTransform>();
        startRect = GetComponent<RectTransform>().position;
        textStartRect = text.GetComponent<RectTransform>().position;
        distance = textStartRect - startRect;
    }

    private void Update()
    {
        textCenter = textRect.rect.width + textRect.localPosition.x;
        GetComponent<RectTransform>().localPosition = new Vector2( textCenter + offset, GetComponent<RectTransform>().localPosition.y);
    }
}
