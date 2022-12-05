using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBeetleController : MonoBehaviour
{
    Transform hardTarget;
    Vector3 randomTarget;

    public float targetRange;

    public float moveSpeed;
    public float rotationSpeed;

    bool moving;

    public Transform targetL;
    public Transform targetR;

    Vector3 startPos;

    public GameObject top;
    public GameObject bottom;


    private void Awake()
    {
        hardTarget = targetR;
        moving = true;
        StartCoroutine(ChangeTarget());
        //StartCoroutine(Pause());
        startPos = transform.position;
    }

    private void OnEnable()
    {
        transform.position = startPos;
        hardTarget = targetR;
        moving = true;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        if(moving == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, randomTarget, moveSpeed * Time.deltaTime);

            Vector3 difference = randomTarget - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, rotationZ), rotationSpeed * Time.deltaTime);
        }
    }
    
    IEnumerator ChangeTarget()
    {
        while(moving == true)
        {
            randomTarget = new Vector3(Random.Range(hardTarget.position.x + targetRange, hardTarget.position.x - targetRange), Random.Range(hardTarget.position.y + targetRange, hardTarget.position.y - targetRange), 0);
            yield return new WaitForSeconds(Random.Range(.4f, .7f));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.transform == hardTarget)
        {
            StartCoroutine("DirectionChange");
        } 
        if(other.gameObject == top)
        {
            //Debug.Log("Hit");
            moving = false;
            randomTarget = new Vector3(hardTarget.position.x, hardTarget.position.y - targetRange);
            StartCoroutine("MoveFromEdge");
        }
        if(other.gameObject == bottom)
        {
            //Debug.Log("Hit");
            moving = false;
            randomTarget = new Vector3(hardTarget.position.x, hardTarget.position.y + targetRange);
            StartCoroutine("MoveFromEdge");
        }
    }

    IEnumerator DirectionChange()
    {
        moving = false;
        yield return new WaitForSeconds(Random.Range(.6f, 2));
        if (hardTarget == targetL)
        {
            hardTarget = targetR;
        }
        else
        {
            hardTarget = targetL;
        }
        moving = true;
        StartCoroutine(ChangeTarget());
    }

    IEnumerator MoveFromEdge()
    {
        yield return new WaitForSeconds(.8f);
        moving = true;
        yield return new WaitForSeconds(2f);
        StartCoroutine(ChangeTarget());
    }
    IEnumerator Pause()
    {
        while(moving == true)
        {
            yield return new WaitForSeconds(Random.Range(7f, 10f));
            moving = false;
            yield return new WaitForSeconds(Random.Range(.6f, 2f));
            moving = true;
            StartCoroutine(ChangeTarget());
        }
    }
}
