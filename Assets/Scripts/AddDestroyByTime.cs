using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDestroyByTime : MonoBehaviour
{
    public void Kill()
    {
        StartCoroutine("DestroyWait");
    }

    IEnumerator DestroyWait()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);

    }
}
