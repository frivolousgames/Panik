using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider playerHealthbar;
    public Animator playerAnim;
    CapsuleCollider2D hitCollider;
    int maxHealth;
    public static int health;
    public static bool isHit;
    public static bool isDead;
    GameObject[] enemies;
    GameObject[] lightShots;
    GameObject[] medShots;
    GameObject[] heavyShots;

    public static bool hitFromRight;



    private void Awake()
    {
        hitCollider = GetComponent<CapsuleCollider2D>();
        maxHealth = 100;
        
        if(GameController.lifeAmount < 2)
        {
            health = maxHealth;
        }
        else
        {
            health = (int)GameController.lifeAmount;
        }
        playerHealthbar.value = health;
        isHit = false;
        isDead = false;

    }

    private void Update()
    {
        playerHealthbar.value = health;
        Died();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        lightShots = GameObject.FindGameObjectsWithTag("LightDamage");
        medShots = GameObject.FindGameObjectsWithTag("MedDamage");
        heavyShots = GameObject.FindGameObjectsWithTag("HeavyDamage");

        //Debug.Log("HitFromRight " + hitFromRight);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (isHit == false)
        {
            
            if (lightShots != null)
            {
                foreach (GameObject shot in lightShots)
                {
                    if (other.gameObject == shot)
                    {
                        health -= PlayerDamage.lightDamage;
                        isHit = true;
                        hitCollider.enabled = false;
                        if(shot.transform.localScale.x < 1)
                        {
                            hitFromRight = true;
                        }
                        else
                        {
                            hitFromRight = false;
                        }
                    }
                }
            }
            if(medShots != null)
            {
                foreach (GameObject shot in medShots)
                {
                    if (other.gameObject == shot)
                    {
                        health -= PlayerDamage.medDamage;
                        isHit = true;
                        hitCollider.enabled = false;
                        if (shot.transform.localScale.x < 1)
                        {
                            hitFromRight = true;
                        }
                        else
                        {
                            hitFromRight = false;
                        }
                    }
                }
            }
            if(heavyShots != null)
            {
                foreach (GameObject shot in heavyShots)
                {
                    if (other.gameObject == shot)
                    {
                        health -= PlayerDamage.heavyDamage;
                        isHit = true;
                        hitCollider.enabled = false;
                        if (shot.transform.localScale.x < 1)
                        {
                            hitFromRight = true;
                        }
                        else
                        {
                            hitFromRight = false;
                        }
                    }
                }
            }
            if (enemies != null)
            {
                foreach (GameObject enemy in enemies)
                {
                    if (other.gameObject == enemy)
                    {
                        health -= PlayerDamage.contact;
                        isHit = true;
                        hitCollider.enabled = false;
                        if (enemy.transform.localScale.x < 1)
                        {
                            hitFromRight = true;
                        }
                        else
                        {
                            hitFromRight = false;
                        }
                    }
                }
            }
        }
        
    }

    

    
    IEnumerator HitWait()
    {
        yield return null;
        isHit = false;
    }

    void Died()
    {
        if(health < 1)
        {
            isDead = true;
            hitCollider.enabled = false;
            StartCoroutine("ResetDeadBool");
        }
    }

    IEnumerator ResetDeadBool()
    {
        yield return null;
        isDead = false;
        health = 1;
    }

    public void InstantDeath()
    {
        health = 0;
    }
    
}
