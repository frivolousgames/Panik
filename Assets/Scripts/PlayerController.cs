using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    //Cam
    public CinemachineVirtualCamera deathCam;
   
    //Grounded
    bool isGrounded;
    public LayerMask groundLayer;
    BoxCollider2D feet;
    //Movement
    Rigidbody2D rb;
    public float jumpForce;
    bool isIdle;
    float movement;

    Vector2 dir;
    public float speed = 5;

    //Crouch
    bool isCrouching;
    //Chute
    public GameObject chute;
    bool chuteActive;
    public float chuteDrag;
    bool chuteCancel;
    private bool chuteFound;

    //Balloon
    public GameObject balloon;
    bool balloonActive;
    public float balloonForce;

    //Shooting
    public GameObject bullet_01;
    public Transform bulletSpawnPos;
    Vector2 crouchGunPos;
    Vector3 standingGunPos;
    Vector2 crouchBulletPos;
    GameObject gun;
    private bool justShot;
    float shotWaitTime;
    public static bool isShooting;
    
    public GameObject flame;
    public Transform flameSpawnPos;
    GameObject fireClone;
    ParticleSystem.MainModule firePart;

    public Transform missileSpawn;
    public GameObject missile;

    bool defaultGun;
    bool flamethrower;
    bool bazooka;

    public GameObject defaultGunArm;
    public GameObject flameArm;
    public GameObject bazookaArm;

    bool hasGun;

    //Animation
    public Animator anim;
    AnimatorStateInfo animInfo;
    Animator gunAnim;

    //Click Zones
    public Button jumpZone;
    public Button crouchZone;
    public Button shootZone;

    //Hit
    public float kickBack;
    public float kickUp;
    private bool hit;
    private bool reflex;
    public SpriteRenderer sr;
    Color32 normalColor;
    Color32 hitOpacityColor;

    bool goBack;
    public Collider2D hitCollider;

    //Die
    private bool dead;
    public float zoomTime;
    private float deathZoomWait;
    private bool zoomed;
    public GameObject deathPanel;
    Image deathScreen;
    Color color;
    public float colorAdd;

    //Platforms
    public BoxCollider2D physCol;
    public float rayBuffer;
    Collider2D[] groundColliders;
    EdgeCollider2D groundStopper;
    //Spring

    //Freeze

    public static bool isFrozen;

    //Special Moves

    public Text specialButtonText;
        //Dash
    public static bool dash;
    private bool isDash;
    public int dashPower;
    public float dashLength;
    public GameObject dashCollider;
    float currentGravityScale;
    public GameObject dashEmitter;
    //Energy
    public static bool energy;
    public static bool isEnergy; 
    public GameObject energyField;
    public float energyRechargeTime;
    

    //Level Start

    //LiveZoneRaycaster

    //float distance;

    //private PointerEventData clicked;

    private void Awake()
    {
        //DEBUG
        dash = true;
        //energy = true;
        //DEBUG

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, 0f);
        if (GameObject.FindGameObjectWithTag("Gun") != null)
        {
            gun = GameObject.FindGameObjectWithTag("Gun");
            standingGunPos = gun.transform.localPosition;
            crouchGunPos = new Vector2(gun.transform.localPosition.x, gun.transform.localPosition.y - .289f);
            gunAnim = gun.GetComponent<Animator>();
        }
        deathScreen = deathPanel.GetComponent<Image>();
        SetStartPosition();
        SetStartGunArm();
        feet = GetComponent<BoxCollider2D>();
        groundStopper = GetComponent<EdgeCollider2D>();
    }

    private void Start()
    {
       
        deathPanel.SetActive(false);
        normalColor = sr.color;
        hitOpacityColor = new Color(sr.color.r, sr.color.g, sr.color.b, 145);
        //groundColliders = Physics2D.
    }

    private void Update()
    {

        //Debug.Log("Is Frozen: " + isFrozen);
        if (isFrozen != true)
        {
            //Movement
            FlipSprite();
            ReverseDirection();
            //IsIdle();
            //Jump

            //Chute
            CloseChute();
            anim.SetBool("chuteActive", chuteActive);
            chuteFound = GameController.hasChute;

            //DeployChute();

            //Balloon
            

            //Shoot
            //-0.115 - -0.404  -0.00499 - -0.3
            crouchBulletPos = new Vector2(bulletSpawnPos.transform.position.x, bulletSpawnPos.transform.position.y - .289f);
            //SetShotWait();

            //Gun
            if(HasGunArm() != false)
            {
                SetGunArm();
            }
            HasGun();
            if (hasGun)
            {
                gun = GameObject.FindGameObjectWithTag("Gun");
                standingGunPos = gun.transform.localPosition;
                crouchGunPos = new Vector2(gun.transform.localPosition.x, gun.transform.localPosition.y - .289f);
                gunAnim = gun.GetComponent<Animator>();
                
            }
            
            defaultGun = GameController.defaultGun;
            flamethrower = GameController.flamethrower;
            bazooka = GameController.bazooka;

            //Animation
            

            //Hit
            HitReaction();

            //Die
            Dead();
            Zoomed();
            Faded();

            //Spring

            //Continue
            LoadContinueScene();
            
        }
        //Balloon
        BalloonActive();

        //Player
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isIdle", isIdle);
        anim.SetBool("chuteCancel", chuteCancel);
        anim.SetBool("isCrouching", isCrouching);

        //Gun
        if(gun!= null)
        {
            gunAnim.SetBool("isCrouching", isCrouching);
            gunAnim.SetBool("isIdle", isIdle);
            gunAnim.SetBool("isGrounded", isGrounded);
        }



        if (hasGun)
        {
            

        }

        //Balloon
        anim.SetBool("BalloonActive", balloonActive);

        

        IsIdle();
        //Debug
        //Debug.Log("flamethrower " + flamethrower);
        //Debug.Log("Balloon Active: " + balloonActive);

        //Special Moves
        SetSpecialBools();
        DashCancel();
    }

    private void FixedUpdate()
    {
        if(isFrozen != true)
        {
            Move();
            ChuteDrag();
        }
        isGrounded = Physics2D.IsTouchingLayers(feet, groundLayer);

        BalloonForce();

        //IgnorePlatformCollision();
        //Debug.Log(Input.acceleration.y);

        //LiveZoneRaycaster
        /*LayerMask liveMask = LayerMask.GetMask("LiveZone");
        RaycastHit2D hitFront = Physics2D.Raycast(transform.position, Vector2.right * 50, liveMask);
        if(hitFront.collider != null)
        {
            float distance = Mathf.Abs(hitFront.point.x - transform.position.x);
            if(distance < 10)
            {
                Debug.Log(distance);
            }
        }*/

    }
    //JUMP
    public void Jump()
    {
        if(isFrozen != true && isDash != true && isEnergy != true)
        {
            if (isGrounded == true && SpringCollider.springing != true)
            {

                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    //MOVE
    void Move()
    {
            if (dead != true)
            {
                if (SpringCollider.springing != true && balloonActive != true)
                {
                    if (hit != true)
                    {
                        if (chuteActive != true)
                        {
                            if (isCrouching != true && isDash != true && isEnergy != true)
                            {
                                dir = Vector2.zero;
                                dir.x = Input.acceleration.x;
                                dir *= Time.deltaTime;
                                dir = new Vector2(Mathf.Clamp(dir.x, -.003f, .003f), 0);

                                if (dir.x > .001f || dir.x < -.001f)
                                {
                                    rb.velocity = new Vector2((dir.x * speed), rb.velocity.y);
                                }
                                else
                                {
                                    dir = Vector2.zero;
                                    rb.velocity = new Vector2(0f, rb.velocity.y);
                                }
                            }
                        }
                        else
                        {
                            dir = Vector2.zero;
                            dir.x = Input.acceleration.x;
                            dir *= Time.deltaTime;
                            dir = new Vector2(Mathf.Clamp(dir.x, -.004f, .004f), 0);
                            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);

                        }
                    }
                    else
                    {
                        rb.velocity = Vector2.zero;
                        if (reflex == true)
                        {
                            HitDirection();
                            if (goBack == true)
                            {
                                rb.AddForce(new Vector2(-kickBack, -kickUp), ForceMode2D.Impulse);
                            }
                            else
                            {
                                rb.AddForce(new Vector2(kickBack, kickUp), ForceMode2D.Impulse);
                            }

                            reflex = false;
                        }
                    }
                }
                else
                {
                    return;
                }

            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        
    }

    void FlipSprite()
    {
        Vector3 playerScale = transform.localScale;

        if(dir.x < -.001f)
        {
            playerScale = new Vector3(-1, 1, 1);
        }
        if (dir.x > .001f)
        {
            playerScale = new Vector3(1, 1, 1);
        }
        transform.localScale = playerScale;
    }

    void ReverseDirection()
    {
        if (transform.localScale.x > 0f)
        {
            movement = dir.x;
        }
        else
        {
            movement = -dir.x;
        }
        anim.SetFloat("Movement", movement);
    }

    void IsIdle()
    {
        if (movement == 0f)
        {
            isIdle = true;
        }
        else
        {
            isIdle = false;
        }
    }

    //CROUCH
    public void Crouch()
    {
        if(isFrozen != true)
        {
            isCrouching = true;
        }
        
        /*if(isIdle == true && isGrounded == true)
        {
            gun.transform.localPosition = new Vector2(gun.transform.localPosition.x, -.404f);

        }*/
    }

    public void UnCrouch()
    {
        isCrouching = false;
        /*if (isIdle == true && isGrounded == true)
        {
            gun.transform.localPosition = standingGunPos;

        }*/
    }

    
    //CHUTE

    void CloseChute()
    {
        if (chuteFound)
        {
            if (isGrounded == true)
            {
                chuteActive = false;
                chute.SetActive(false);
            }
        }
    }

    public void DeployChute()
    {
        if(chuteFound != false)
            
        {
            if (balloonActive != true)
            {
                if (isGrounded != true)
                {
                    if (rb.velocity.y < .1f && chute.activeInHierarchy == false)
                    {
                        if (chuteCancel != true)
                        {
                            chute.SetActive(true);
                            chuteActive = true;
                            Debug.Log("ChuteActive: " + chuteActive);
                        }
                    }

                }
                else
                {
                    chuteActive = false;
                    chute.SetActive(false);
                }
            }  
        }
        //anim.SetBool("chuteActive", chuteActive);
    }

    public void IsChuteCancelled()
    {
        if(chuteFound != false)
        {
            if (balloonActive != true)
            {
                if (isGrounded != true)
                {
                    if (chuteActive == true)
                    {
                        if (chuteCancel == false)
                        {
                            chuteCancel = true;
                            chute.SetActive(false);
                            chuteActive = false;
                        }
                    }
                    else
                    {
                        chuteCancel = false;
                        chute.SetActive(true);
                        chuteActive = true;
                    }

                }
                else
                {
                    chuteCancel = false;
                }
            }  
        }
    }
    void HitChuteClose()
    {
        if (chuteActive == true)
        {
            if (chuteCancel == false)
            {
                chuteCancel = true;
                chute.SetActive(false);
                chuteActive = false;
            }
        }
    }

    void ChuteDrag()
    {
        if(chuteActive == true)
        {
            rb.drag = chuteDrag;
            rb.angularDrag = chuteDrag;
        }
        else
        {
            rb.drag = 2f;
            rb.angularDrag = 2f;
        }
    }

    //Balloon

    void BalloonActive()
    {
        if(balloon != null)
        {
            if (balloon.activeInHierarchy != false)
            {
                balloonActive = true;
            }
            else
            {
                balloonActive = false;
            }
        }
    }

    void BalloonForce()
    {
        if (balloonActive != false)
        {
            rb.AddForce(Vector2.up * balloonForce);
        }
    }

    //SHOOT
    public void Shoot()
    {
        if(isFrozen != true)
        {
            if(defaultGun != false)
            {
                if (justShot == false)
                {
                    if (isCrouching == true)
                    {
                        Instantiate(bullet_01, crouchBulletPos, Quaternion.identity, transform);
                    }
                    else
                    {
                        Instantiate(bullet_01, bulletSpawnPos.position, Quaternion.identity, transform);
                    }
                    justShot = true;
                    StartCoroutine("ShotWait");
                }
                shotWaitTime = .2f;
            }
            if(flamethrower != false)
            {
                fireClone = Instantiate(flame, flameSpawnPos.position, Quaternion.identity, flameSpawnPos);
                isShooting = true;
            }
            if(bazooka != false)
            {
                if (justShot == false)
                {
                    Instantiate(missile, missileSpawn.position, Quaternion.identity, transform);
                    justShot = true;
                    StartCoroutine("ShotWait");
                }
                shotWaitTime = .5f;
            }
        }
    }

    public void DestroyFire()
    {
        if(fireClone != null)
        {
            firePart = fireClone.GetComponent<ParticleSystem>().main;
            firePart.loop = false;
        }
        isShooting = false;
    }

    IEnumerator ShotWait()
    {
        yield return new WaitForSeconds(shotWaitTime);
        justShot = false;
    }

    void SetShotWait()
    {
        shotWaitTime = .2f;
    }

    void SetGunArm()
    {
        if(defaultGun == true)
        {
            defaultGunArm.SetActive(true);
            flameArm.SetActive(false);
            bazookaArm.SetActive(false);
            flamethrower = false;
            bazooka = false;
        }
        else if(flamethrower == true)
        {
            defaultGunArm.SetActive(false);
            flameArm.SetActive(true);
            bazookaArm.SetActive(false);
            defaultGun = false;
            bazooka = false;

        }
        else if (bazooka == true)
        {
            defaultGunArm.SetActive(false);
            flameArm.SetActive(false);
            bazookaArm.SetActive(true);
            defaultGun = false;
            flamethrower = false;
        }
        else
        {
            defaultGunArm.SetActive(false);
            flameArm.SetActive(false);
            bazookaArm.SetActive(false);
        }

    }
    void HasGun()
    {
        if (GameObject.FindGameObjectWithTag("Gun") != null)
        {
            hasGun = true;
        }
        else
        {
            hasGun = false;
        }
    }
    bool HasGunArm()
    {
        if(defaultGunArm != null || flameArm != null || bazookaArm != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /*void SetGunArm(bool gun)
    {
        switch (gun)
        {
            case defaultGun:
                defaultGunArm.SetActive(true);
                flameArm.SetActive(false);
                bazookaArm.SetActive(false);
                flamethrower = false;
                bazooka = false;
                break;
        }
    }*/

    //HIT
    void HitReaction()
    {
        if (PlayerHealth.isHit == true)
        {
            
            if (isGrounded == true)
            {
                rb.velocity = Vector2.zero;
                hit = true;
                reflex = true;
                StartCoroutine("HitWait");   
            }
            else
            {
                HitChuteClose();  
            }
            PlayerHealth.isHit = false;
            sr.color = new Color32(255, 100, 100, 255);
            StartCoroutine("SetHitOpacity");
            if (animInfo.tagHash != Animator.StringToHash("Hit"))
            {
                anim.SetTrigger("Hit");

            }
        }
    }
    
    IEnumerator HitWait()
    {
        yield return new WaitForSeconds(.08f);
        hit = false;
    }
    IEnumerator SetHitOpacity()
    {
        yield return new WaitForSeconds(.2f);
        sr.color = new Color32(255, 255, 255, 130);
        StartCoroutine("EnableHitCollider");
    }
    IEnumerator EnableHitCollider()
    {
        yield return new WaitForSeconds(.8f);
        if(dead == false)
        {
            hitCollider.enabled = true;
        }
        sr.color = normalColor;
    }
    void HitDirection()
    {
        if(PlayerHealth.hitFromRight == true && transform.localScale.x > 0)
        {
            goBack = true;
        }
        else if(PlayerHealth.hitFromRight == true && transform.localScale.x < 0)
        {
            goBack = true;
        }
        else
        {
            goBack = false;
        }
    }

    //DIE
    void Dead()
    {
        if(PlayerHealth.isDead == true)
        {
            StartCoroutine("DieWait");
        }
    }

    IEnumerator DieWait()
    {
        while(animInfo.tagHash == Animator.StringToHash("Hit"))
        {
            yield return null;
        }
        rb.isKinematic = true;
        if (hasGun)
        {
            gun.SetActive(false);

        }
        deathPanel.SetActive(true);
        StartCoroutine("DeathZoom");
        StartCoroutine("FadeWait");
        anim.SetTrigger("Die");
        dead = true;
        if (chuteActive == true)
        {
            chuteActive = false;
        }
    }

    IEnumerator DeathZoom()
    {
        if(!deathCam.gameObject.activeInHierarchy)
        {
            deathCam.gameObject.SetActive(true);
        }
        while (Zoomed() == false)
        {
            deathCam.m_Lens.OrthographicSize -= zoomTime * Time.deltaTime;
            yield return null;
        }

    }

    IEnumerator FadeWait()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine("DeathFade");
    }

    IEnumerator DeathFade()
    {
        while (Faded() == false)
        {
            color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, deathScreen.color.a + colorAdd * Time.deltaTime);
            deathScreen.color = color;
            yield return null;
        }
    }

    bool Faded()
    {
        if(deathScreen.color.a > 5)
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }

    bool Zoomed()
    {
        if(deathCam.m_Lens.OrthographicSize < 2)
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }

    public void DieOffScreen()
    {
        StartCoroutine("DeathFade");
    }

    void LoadContinueScene()
    {
        if(Faded() == true)
        {
            SceneManager.LoadScene("Continue");
        }
    }

    //Platforms
    void IgnorePlatformCollision()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + rayBuffer), Vector2.down, 1f, groundLayer);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + rayBuffer), Vector2.down * 1f, Color.blue);
        if(hit.collider == null)
        {
            //Physics2D.IgnoreCollision(feet, hit.collider);
            groundStopper.enabled = false;
        }
        else
        {
            //Physics2D.IgnoreCollision(feet, hit.collider, false);
            groundStopper.enabled = true;
        }
    }
    

    //Spring

    //Freeze

    public void Freeze()
    {
        isFrozen = true;
        rb.velocity = Vector2.zero;
    }

    public void UnFreeze()
    {
        isFrozen = false;
        //anim.speed = 1;
    }

    //Level Start

    void SetStartPosition()
    {
        if(GameController.returnToAreaPosition != Vector2.zero && GameController.returnToAreaXScale != 0)
        {
            transform.position = GameController.returnToAreaPosition;
            transform.localScale = new Vector2(GameController.returnToAreaXScale, 1);
            StartCoroutine("ResetStartPosition");
            
        }
    }

    IEnumerator ResetStartPosition()
    {
        yield return new WaitForSeconds(.1f);
        GameController.returnToAreaPosition = Vector2.zero;
    }

    //Weapon Select

    //Insanity
    public void EnterSanity()
    {
        StartCoroutine("GoSane");
    }
    IEnumerator GoSane()
    {
        while (animInfo.tagHash == Animator.StringToHash("Hit"))
        {
            yield return null;
        }
        rb.isKinematic = true;
        if (hasGun)
        {
            gun.SetActive(false);

        }
        dead = true;
        if (chuteActive == true)
        {
            chuteActive = false;
        }
        anim.SetTrigger("Sanity");
    }

    //Load At Start
    void SetStartGunArm()
    {
        if(GameController.equippedWeapon != null)
        {
            if(GameController.equippedWeapon == "Default_gun")
            {
                defaultGunArm.SetActive(true);
            }
            else if (GameController.equippedWeapon == "Bazooka")
            {
                bazookaArm.SetActive(true);
            }
            else if (GameController.equippedWeapon == "FlameThrower")
            {
                flameArm.SetActive(true);
            }
        }
    }

    //Special Moves
    void SetSpecialBools()
    {
        if(specialButtonText != null)
        {
            if (dash == true)
            {
                specialButtonText.text = "Dash";
                energy = false;
            }
            else if (energy == true)
            {
                specialButtonText.text = "Energy";
                dash = false;
            }
            else
            {
                specialButtonText.text = "";
            }
        }
        
    }
    public void Special()
    {
        if(dash == true)
        {
            if (GameController.HasDash() == true)
            {
                currentGravityScale = rb.gravityScale;
                
                if (isDash != true && chuteActive != true && isGrounded != true && balloonActive != true)
                {
                    isDash = true;
                    anim.SetTrigger("Dash");
                    rb.gravityScale = 0;
                    hitCollider.enabled = false;
                    Instantiate(dashCollider, transform);
                    GameObject dashFab = Instantiate(dashEmitter, transform.position, Quaternion.identity, transform);
                    dashFab.transform.localScale = new Vector2(transform.localScale.x, dashFab.transform.localScale.y);
                    if (transform.localScale.x > 0)
                    {
                        rb.velocity = Vector2.right * dashPower;
                    }
                    else
                    {
                        rb.velocity = -Vector2.right * dashPower;
                    }
                    StartCoroutine("EndDash");
                }
            }
        }
        if(energy == true)
        {
            if(GameController.HasEnergy() == true)
            {
                if(isEnergy != true && isGrounded == true && balloonActive != true)
                {
                    if (animInfo.tagHash != Animator.StringToHash("Energy"))
                    {
                        isEnergy = true;
                        Instantiate(energyField, transform);
                        anim.SetTrigger("Energy");
                    }
                }  
            }
        }
        
    }

    IEnumerator EndDash()
    {
        yield return new WaitForSeconds(dashLength);
        rb.gravityScale = currentGravityScale;
        rb.velocity = Vector2.zero;
        hitCollider.enabled = true;
    }

    void DashCancel()
    {
        if(isGrounded == true)
        {
            isDash = false;
        }
    }

}
