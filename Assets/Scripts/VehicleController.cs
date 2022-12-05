using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Vector3 rbVelocity;
    protected bool isJumping;
    public float jumpPower;

    protected bool isGrounded;
    public LayerMask groundLayer;
    public BoxCollider2D groundCollider;

    public float speed;

    //Shoot
    protected bool isShooting;
    public GameObject bullet;
    public Transform bulletSpawnPos;
    public float shotWaitTime;
    public GameObject muzzleFlash;
    public float bulletSpeed;

    public virtual void Jump()
    {
        if(isGrounded == true)
        {
            isJumping = true;
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            Debug.Log("JUMP");
        }
    }

    public virtual void Shoot()
    {
        if(isShooting == false)
        {
            isShooting = true;
            GameObject bFab = Instantiate(bullet, bulletSpawnPos.position, transform.rotation, transform);
            bFab.GetComponent<MultiAngleShooter>().speed = bulletSpeed;
            Instantiate(muzzleFlash, bulletSpawnPos.position, transform.rotation, transform);
            StartCoroutine("ShotWait");
            Debug.Log("Shoot");
        }
    }

    public virtual void SlamWheelOnLanding()
    {
        
    }

    IEnumerator ShotWait()
    {
        yield return new WaitForSeconds(shotWaitTime);
        isShooting = false;
    }
}


