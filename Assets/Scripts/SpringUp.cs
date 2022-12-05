using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpringUp : MonoBehaviour
{
    public UnityEvent spring;

 public void Spring()
    {
        spring.Invoke();
    }
}
