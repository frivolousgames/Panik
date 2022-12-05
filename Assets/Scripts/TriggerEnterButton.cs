using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEnterButton : MonoBehaviour
{
    GameObject player;

    public GameObject enterButton;
    public static bool nearTalker;

    private void Start()
    {
        nearTalker = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(GameObject.FindGameObjectWithTag("EnterHouseButton") == null)
        {
            if (other.gameObject == player)
            {
                if (!enterButton.activeInHierarchy)
                {
                    enterButton.SetActive(true);
                }
                nearTalker = true;
                /*if (enterButton.enabled != true)
                {
                    enterButton.enabled = true;
                }*/
            }
        }   
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (enterButton.activeInHierarchy)
            {
                enterButton.SetActive(false);

            }
            nearTalker = false;
        }
    }
}
