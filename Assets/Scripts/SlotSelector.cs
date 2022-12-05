using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSelector : MonoBehaviour
{
    public BoxCollider2D clicker;

    public static string slot;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == clicker)
        {
            slot = gameObject.name;
        }
    }
}
