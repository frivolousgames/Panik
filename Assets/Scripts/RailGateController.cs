using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGateController : MonoBehaviour
{
    public float loweredPosY;
    public float speed;

    BoxCollider2D col;

    GameObject player;

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Lowered();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            //EXPLODE
        }
    }

    public void LowerGate()
    {
        StartCoroutine("Move");
        col.enabled = false;
    }

    bool Lowered()
    {
        if(transform.localPosition.y > loweredPosY)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    IEnumerator Move()
    {
        while (Lowered() == false)
        {
            transform.localPosition += new Vector3(0, -1 * Time.deltaTime * speed);
            yield return null;
        }
        
    }
}
