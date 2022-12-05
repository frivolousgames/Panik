using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    GameObject cam;
    public float x;
    public float y;
    float adjustedY;

    GameObject player;
    Rigidbody2D rb;

    float startPosition;
    float length;
    float distance;

    Vector3 camPosition;
    bool isCamMoving;

    private void Awake()
    {
        name = name.Replace("(Clone)", "");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x;   
        //Debug.Log(length);
        camPosition = cam.transform.localPosition;
    }

    private void Update()
    {
        adjustedY = transform.parent.position.y * y;
        transform.position = new Vector2(transform.position.x, adjustedY);
        distance = cam.transform.position.x;
        IsCameraMoving();
        MoveBackground();
        ChangePosition();
        //Debug.Log("Cam Moving: " + isCamMoving);
    }

    void MoveBackground()
    {
        if(isCamMoving != false)
        {
            if (rb.velocity.x > .1f)
            {
                transform.Translate(-Vector2.right * Time.deltaTime * x);
            }
            else if (rb.velocity.x < -.1f)
            {
                transform.Translate(Vector2.right * Time.deltaTime * x);
            }
            else
            {
                return;
            }
        }        
    }

    void ChangePosition()
    {
        if (transform.position.x > distance + length * 2)
        {
            transform.position -= new Vector3(length * 3, adjustedY);
        }
        else if (transform.position.x < distance - length * 2)
        {
            transform.position += new Vector3(length * 3, adjustedY);
        }
    }
    void IsCameraMoving()
    {
        if (cam.transform.localPosition.x < camPosition.x - .001f || cam.transform.localPosition.x > camPosition.x + .001f)
        {
            isCamMoving = true;
            camPosition = cam.transform.position;
        }
        else
        {
            isCamMoving = false;
        }
    }
}
