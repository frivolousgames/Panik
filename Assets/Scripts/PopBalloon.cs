using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopBalloon : MonoBehaviour
{
    public void StopVelocity()
    {

    }

    public void DeactivateBalloon()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
