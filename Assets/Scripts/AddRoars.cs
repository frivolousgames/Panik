using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddRoars : MonoBehaviour
{
    public UnityEvent roar;

    public void Roar()
    {
        roar.Invoke();

    }
}
