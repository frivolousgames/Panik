using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerStart : MonoBehaviour
{
    bool on;
    public Animator anim;
    public UnityEvent shoot;
    public UnityEvent shootNow;
    public float shotWaitTime;

    private void Update()
    {
        anim.SetBool("On", on);
        Shoot();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            shootNow.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            if (on == false)
            {
                on = true;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            on = false;
        }
    }

    void Shoot()
    {
        if(on == true)
        {
            StartCoroutine("ShootCycle");
        }
    }

    IEnumerator ShootCycle()
    {
        shoot.Invoke();
        yield return new WaitForSeconds(shotWaitTime);
    }

    /*IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(.1f);
        on = false;
    }*/

}
    

    

