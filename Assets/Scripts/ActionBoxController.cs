using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBoxController : MonoBehaviour
{
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
