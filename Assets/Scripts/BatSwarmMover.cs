using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSwarmMover : MonoBehaviour
{
    public Transform secondTargetPos;
    public Transform firstTargetPos;
    public float speed;
    float increment;
    float lerpSpeed;
    float targetYPos;
    float targetPosX;

    bool startMoving;

    private void Awake()
    {
        increment = Random.Range(.1f, .3f);
        lerpSpeed = Random.Range(0f, .03f);
        targetYPos = Random.Range(-2f, 2f);
        targetPosX = Random.Range(-10f, 10f);
    }

    private void Update()
    {
        if(startMoving == false)
        {
            if (lerpSpeed < 1f)
            {
                lerpSpeed += increment * Time.deltaTime;
            }
            //Debug.Log(lerpSpeed);
            transform.position = Vector3.Lerp(transform.position, Vector3.Lerp(new Vector3(firstTargetPos.position.x + targetYPos, firstTargetPos.position.y + targetYPos, 0f), new Vector3(secondTargetPos.position.x + targetPosX, secondTargetPos.position.y + targetYPos, 0), lerpSpeed), lerpSpeed);
        }
    }

    public void StartMoving()
    {
        startMoving = true;
    }
}
