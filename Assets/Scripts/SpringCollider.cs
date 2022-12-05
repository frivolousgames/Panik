using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpringCollider : MonoBehaviour
{
    GameObject[] springs;
    GameObject[] sideSprings;
    public static bool springing;
    public Animator anim;
    public Rigidbody2D rb;
    public float springPower;
    float springAngle;
    public UnityEvent springUp;

    private void Update()
    {
        springs = GameObject.FindGameObjectsWithTag("Spring");
        sideSprings = GameObject.FindGameObjectsWithTag("SideSpring");
        anim.SetBool("IsSpringing", springing);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (springs != null)
        {
            foreach (GameObject spring in springs)
            {
                if (other.gameObject == spring && springing == false)
                {
                    springAngle = 0f;
                    springPower = 75f;
                    anim.SetTrigger("SpringUp");
                    StartCoroutine("SpringAnimWait");
                    springUp.Invoke();
                    StartCoroutine("SpringBoolReset");
                    springing = true;
                }
            }
        }
        if (sideSprings != null)
        {
            foreach (GameObject spring in sideSprings)
            {
                if (other.gameObject == spring && springing == false)
                {
                    springAngle = 60f;
                    springPower = 60f;
                    anim.SetTrigger("SpringUp");
                    StartCoroutine("SpringAnimWait");
                    springUp.Invoke();
                    StartCoroutine("SpringBoolReset");
                    springing = true;
                }
            }
        }
    }

    IEnumerator SpringBoolReset()
    {
        yield return new WaitForSeconds(.3f);
        springing = false;
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        springing = false;
    }*/

    public void SpringUp()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        

        /*if (springing == true)
        {
            springPower *= 2;
        }*/
    }
    IEnumerator SpringAnimWait()
    {
        yield return new WaitForSeconds(.1f);
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(springAngle, springPower), ForceMode2D.Impulse);
    }
}
