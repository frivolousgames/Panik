using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParent : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
