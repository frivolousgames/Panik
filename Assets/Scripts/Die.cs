using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public void DestroyGameobject()
    {
        Destroy(transform.parent.gameObject);
    }
}
