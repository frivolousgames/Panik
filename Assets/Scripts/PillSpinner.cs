using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillSpinner : MonoBehaviour
{
    public float speed;
    

    void Update()
    {
        transform.rotation = new Quaternion(0, 0, Mathf.PingPong(speed, 180f), 0);
    }
}
