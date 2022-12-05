using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWheelRotation : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Rotate(0f, 0f, speed);
    }
}
