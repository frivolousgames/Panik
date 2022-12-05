using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelParentRotation : MonoBehaviour
{

    public GameObject parentT;

    private void Update()
    {
        //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, parentT.transform.rotation.z - transform.rotation.z, 1f);
        transform.rotation = Quaternion.identity;
    }
}
