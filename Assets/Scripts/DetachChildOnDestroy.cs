using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachChildOnDestroy : MonoBehaviour
{

    private void OnDestroy()
    {
        transform.DetachChildren();
    }
}
