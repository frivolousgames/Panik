using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpace : MonoBehaviour
{
    public GameObject player;
    public GameObject col;

    ParticleSystem.MainModule psMain;

    Vector2 lastPos;
    bool stopped = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        psMain = GetComponent<ParticleSystem>().main;
    }
    private void Update()
    {

        if(psMain.loop == false)
        {
            if(stopped != true)
            {
                //Debug.Log("NOT LOOPING");
                lastPos = transform.localScale;
                transform.parent = null;
                transform.localScale = lastPos;
                
                stopped = true;
                Destroy(col);
                StartCoroutine("DestroyFlame");
            }
            
        }
        else
        {
            transform.localScale = player.transform.localScale;
        }
        if(col != null)
        {
            col.transform.localScale = transform.localScale;

        }
    }

    IEnumerator DestroyFlame()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
