using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    GameObject[] defaultBullets;
    GameObject[] missiles;
    public int health;
    public bool isDead;
    public UnityEvent die;
    public UnityEvent hit;

    public UnityEvent thresholdReached;
    public int healthThreshold;
    bool isThresh = false;
    public Slider healthSlider;

    private void Awake()
    {
        isDead = false;
        //healthSlider.value = health;
    }

    private void Update()
    {
        defaultBullets = GameObject.FindGameObjectsWithTag("Default Bullet");
        missiles = GameObject.FindGameObjectsWithTag("Missile");
        Die();
        //Debug.Log("Dead " + isDead);
        ReachHealthThreshold();

        if(healthSlider != null)
        {
            healthSlider.value = health;
        }
        if(health < 1 && healthSlider != null)
        {
            Destroy(healthSlider.gameObject);
        }
        

        //Debug.Log("Healthbar " + healthSlider.value);
        //Debug.Log("Health " + health);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(defaultBullets != null)
        {
            foreach (GameObject bullet in defaultBullets)
            {
                if (other.gameObject == bullet)
                {
                    health -= 5;
                    hit.Invoke();
                }

            }
        }
        if (missiles != null)
        {
            foreach (GameObject missile in missiles)
            {
                if (other.gameObject == missile)
                {
                    health -= 15;
                    hit.Invoke();
                }

            }
        }
    }
    /*void Die()
    {
        if(health < 1)
        {
            isDead = true;
            StartCoroutine("ResetHealth");
        }
        else
        {
            isDead = false;
        }
    }*/
    IEnumerator ResetHealth()
    {
        yield return null;
        health = 100;
        if(isDead == true)
        {
            isDead = false;
            die.Invoke();
        }
    }

    void Die()
    {
        if(health < 1)
        {
            isDead = true;
            StartCoroutine("ResetHealth");
        }
    }

    void ReachHealthThreshold()
    {
        if(isThresh == false)
        {
            if (health <= healthThreshold)
            {
                thresholdReached.Invoke();
                isThresh = true;
            }
        }
        
    }
}
