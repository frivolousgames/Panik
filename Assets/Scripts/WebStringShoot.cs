using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebStringShoot : MonoBehaviour
{
    public GameObject webString;
    bool shooting;

    public float targetPosY;
    public float targetScaleY;

    public float shootSpeed;
    float scaleSpeed;

    private void Awake()
    {
        StartCoroutine("Shooting");
    }

    private void Update()
    {
        scaleSpeed = shootSpeed * 1.5f;
    }

    public void ShootString()
    {
        shooting = true;
        StartCoroutine("Shooting");
    }

    IEnumerator Shooting()
    {
        while (webString.transform.localScale.y != targetScaleY)
        {
            webString.transform.position = Vector3.MoveTowards(webString.transform.position, new Vector3(webString.transform.position.x, targetPosY, 0), shootSpeed * Time.deltaTime);
            webString.transform.localScale = Vector3.MoveTowards(webString.transform.localScale, new Vector3(webString.transform.localScale.x, targetScaleY, 1), scaleSpeed * Time.deltaTime);
            yield return new WaitForSeconds(.01f);
        }
        yield return null;
    }
}
