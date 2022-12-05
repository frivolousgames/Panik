using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour
{
    GameObject[] enemies;
    BoxCollider2D col;

    public float waitTime;

    //Animator anim;
    //public bool disable;

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        //anim = GetComponent<Animator>();
        //disable = false;
    }

    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("EnemyHitCollider");
        //Debug.Log("ENabled " + col.isActiveAndEnabled);
        //anim.SetBool("Disable", disable);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(enemies != null)
        {
            foreach (GameObject enemy in enemies)
            {
                if (other.gameObject == enemy && col.isActiveAndEnabled)
                {
                    col.enabled = false;
                    StartCoroutine("ReenableCol");
                }
            }
        }
    }
    IEnumerator ReenableCol()
    {
        yield return new WaitForSeconds(waitTime);
        col.enabled = true;

    }
}
