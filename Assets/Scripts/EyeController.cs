using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    public Animator anim;
    bool eyesDown;

    private void Update()
    {
        anim.SetBool("eyesDown", eyesDown);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (HalluciphoneController.started == true && eyesDown == false)
            {
                eyesDown = true;
            }
        }  
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (HalluciphoneController.started == true && eyesDown == false)
            {
                eyesDown = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (HalluciphoneController.started == true && eyesDown == true)
            {
                eyesDown = false;
            }
        }
    }
}
