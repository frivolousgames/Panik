using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkDeactivate : MonoBehaviour
{
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
