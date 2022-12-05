using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipStopper : MonoBehaviour
{
    float z;
    float y;
    public float offset;
    private void Update()
    {
        z = transform.localEulerAngles.z - transform.parent.localEulerAngles.z;
        transform.rotation = new Quaternion(0, 0, z, 0);
        y = transform.parent.position.y - transform.localPosition.y;
        Debug.Log(y);
        transform.localPosition = new Vector2(transform.localPosition.x, y + offset);
    }
}
