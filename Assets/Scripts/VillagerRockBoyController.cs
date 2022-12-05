using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VillagerRockBoyController : MonoBehaviour
{
    bool moved = false;
    bool walking;
    public Animator anim;
    public GameObject blockCollider;
    Rigidbody2D rb;
    public float moveForce;
    public float walkTime;
    MonoBehaviour vControl;
    public GameObject textSpawn;
    public GameObject actionButton;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        vControl = GetComponent<VillagerController>();
        if(PlayerPrefs.GetString("HatCompleted", "False") == "True")
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        anim.SetBool("Walking", walking);
        HatJustUsed();
        ActivateActionButton();
        
        //Debug.Log("Hat Completed : " + PlayerPrefs.GetString("HatCompleted", "False"));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            GameController.hatUsable = true;
           
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            GameController.hatUsable = false;
            
        }
    }
    private bool HatJustUsed()
    {
        if (PlayerPrefs.GetString("HatCompleted", "False") == "False" && GameController.hatUsed == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private void ActivateActionButton()
    {
        if(HatJustUsed() == true)
        {
            actionButton.SetActive(true);
        }
    }

    IEnumerator MoveAway()
    {
        PlayerPrefs.SetString("HatCompleted", "True");
        yield return new WaitForSeconds(walkTime);
        rb.velocity = Vector2.zero;
        walking = false;
        vControl.enabled = true;
        textSpawn.transform.position = new Vector2(0f, textSpawn.transform.position.y);
        PlayerController.isFrozen = false;
    }

    public void StartMoving()
    {
        if (HatJustUsed() == true)
        {
            blockCollider.SetActive(false);
            walking = true;
            rb.velocity = Vector2.left * moveForce;
            PlayerController.isFrozen = true;
            StartCoroutine("MoveAway");
        }
    }
}
