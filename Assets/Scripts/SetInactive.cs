using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactive : MonoBehaviour
{
    public GameObject emitter;

    public void SetThisInactive()
    {
        gameObject.SetActive(false);
    }

    public void SetEmitterActive()
    {
        {
            emitter.SetActive(true);

        }
    }
    public void SetEmitterInactive()
    {
        {
            emitter.SetActive(false);

        }
    }
}
