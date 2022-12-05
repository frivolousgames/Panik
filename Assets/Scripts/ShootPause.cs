using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPause : MonoBehaviour
{
    Animator anim;
    bool isShooting;
    public static int pauseTime;
    public GameObject bullet;
    public Transform shotSpawn;
    bool isAlive;
    public float shotWait;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        isShooting = false;
        isAlive = true;
        pauseTime = 2;
        StartCoroutine("ShotSchedule");
    }

    private void Update()
    {
        anim.SetBool("isShooting", isShooting);
        
    }

    public void PauseAnimator()
    {
        anim.enabled = false;
        StartCoroutine(AnimatorResume());
        StartCoroutine(Shoot());
    }

    IEnumerator AnimatorResume()
    {
        yield return new WaitForSeconds(pauseTime);
        anim.enabled = true;
        isShooting = false;
    }

    IEnumerator Shoot()
    {
        while(isShooting == true && GameController.freezeAll == false)
        {
            Instantiate(bullet, shotSpawn.position, transform.rotation, transform);
            yield return new WaitForSeconds(.3f);
        }
            
    }

    IEnumerator ShotSchedule()
    {
        while(isAlive == true)
        {
            yield return new WaitForSeconds(shotWait);
            isShooting = true;
        }
    }

    public void Kill()
    {
        isShooting = false;
        isAlive = false;
    }
}
