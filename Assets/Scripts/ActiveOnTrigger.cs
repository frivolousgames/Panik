using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnTrigger : MonoBehaviour
{
    public GameObject go;

    private void OnTriggerEnter2D(Collider2D other)
    {
        go.SetActive(true);
    }
}
