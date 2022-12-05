using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLiveZoneEdge : MonoBehaviour
{
    LayerMask liveZone;

    BoxCollider2D col;

    bool touching;

    private void Awake()
    {
        liveZone = LayerMask.GetMask("LiveZone");
        col = GetComponent<BoxCollider2D>(); 
    }

    private void FixedUpdate()
    {
        touching = Physics2D.IsTouchingLayers(col, liveZone);
        //Debug.Log("touching: " + touching);
    }
}
