using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBubble : MonoBehaviour
{
    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
