using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderRockController : GroundEnemy
{
    AnimatorStateInfo animInfo;

    public GameObject topCollider;
    public GameObject bottomCollider;

    bool isDropping;
    public float dropSpeed;
    public float dropTargetPos;

    bool isClimbing;
    public float climbSpeed;
    float climbTargetPos;

    bool isAttacking;

    public float landPosX;

    Vector2 startClimbPos;
    bool setStartClimbPos;

    bool isWalking;
    public float walkDistance;

    public float minX;
    public float maxX;
    float walkSpeed;

    //WEBSTRING
    public GameObject webString;

    float webStringStartPosY;
    float webStringStartScaleY;

    float webStringEndPosY;
    float webStringEndScaleY;

    bool reachedEnd;

    //Shoot
    bool shooting;

    public float shootTargetPosY;
    public float shootTargetScaleY;
    float shootPos;

    public float shootSpeed;
    float shootScaleSpeed;

    public float dropPosY;
    float dropScaleY;

    public float climbPosY;
    float climbScaleY;

    public float retractPosY;
    public float retractScaleY;
    float retractPos;

    public float retractPosSpeed;
    float retractScaleSpeed;

    //Bullet
    GameObject bulletPrefab;

    //Jump
    public BoxCollider2D groundCheckCol;
    GameObject player;
    CapsuleCollider2D playerCollider;
    public float rayBufferX;
    public float rayBufferY;
    LayerMask playerLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        //rbVelocity = new Vector2(speed, rb.velocity.y);
        groundCol = GetComponent<EdgeCollider2D>();
        borderCol = GetComponent<BoxCollider2D>();
        shootScaleSpeed = shootSpeed * 1.5f;
        dropScaleY = dropPosY * 1.52f;
        retractScaleSpeed = retractPosSpeed * 1.52f;
        climbScaleY = climbPosY * 1.5f;
        climbTargetPos = transform.position.y;

        webStringStartPosY = webString.transform.position.y;
        webStringStartScaleY = webString.transform.localScale.y;
    }

    private void Start()
    {
        playerLayer = LayerMask.GetMask("Player");
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = GameObject.FindGameObjectWithTag("PlayerHitCollider").GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
        anim.SetBool("Dropping", isDropping);
        anim.SetBool("Climbing", isClimbing);
        anim.SetBool("Attacking", isAttacking);
        anim.SetBool("Shooting", shooting);
        anim.SetBool("Grounded", isGrounded);

        Dropping();
        Climbing();
        SetRigidBody();
        WalkingDirection();
        //FacePlayer();
        SetStartClimbPos();

        

        //Debug.Log("Scale: " + webString.transform.localScale.y + " Target: " + retractScaleY);
    }

    private void FixedUpdate()
    {
        if (dead != true)
        {
            if (rb.isKinematic == true)
            {
                rb.velocity = Vector2.zero;
            }
            else
            {
                //rb.velocity = rbVelocity;
                WalkingDirection();
                WalkRoutine();
                FacePlayer();
            }
        }
        
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        isGrounded = Physics2D.IsTouchingLayers(groundCheckCol, groundLayer);
        AttackRaycast();
        
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == topCollider)
        {
            isClimbing = false;
        }
        if(other.gameObject == bottomCollider)
        {
            if(animInfo.tagHash == Animator.StringToHash("Dropping") ||
                animInfo.tagHash == Animator.StringToHash("LineSquirt"))
            {
                anim.ResetTrigger("Land");
                anim.SetTrigger("Land");
                Debug.Log("Land");
                isDropping = false;
                StartCoroutine("StringRetract");
            }     
        }
    }

    void SetStartClimbPos()
    {
        if (setStartClimbPos != true)
        {
            if (animInfo.tagHash == Animator.StringToHash("Land"))
            {
                startClimbPos = transform.position;
                setStartClimbPos = true;
                Debug.Log(startClimbPos);
            }
        }
    }

    void Dropping()
    {
        if(isDropping == true)
        {
            //rbVelocity = Vector2.down * dropSpeed;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, dropTargetPos, 0), dropSpeed * Time.deltaTime);
        }
    }

    void Climbing()
    {
        if (isClimbing == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, climbTargetPos, 0), climbSpeed * Time.deltaTime);
            //rbVelocity = Vector2.up * climbSpeed;
        }
    }

    public void Climb()
    {
        isClimbing = true;
    }

    public void StartRoutine()
    {
        if(animInfo.tagHash == Animator.StringToHash("Idle"))
        {
            //StopAllCoroutines();
            isDropping = true;
            isClimbing = false;
            isAttacking = true;
            StartCoroutine("StringDropping");
        }
        else if(animInfo.tagHash == Animator.StringToHash("LineSquirt"))
        {
            StopAllCoroutines();
            shootPos = webString.transform.localScale.y;
            StartCoroutine("StringRetract");
            anim.ResetTrigger("Land");
            anim.SetTrigger("Land");
            isClimbing = false;
        }
        else if (animInfo.tagHash == Animator.StringToHash("ClimbJump") ||
            animInfo.tagHash == Animator.StringToHash("Climbing") ||
            animInfo.tagHash == Animator.StringToHash("ClimbEnd"))
        {
            StopAllCoroutines();
            isDropping = true;
            isClimbing = false;
            isAttacking = true;
            anim.ResetTrigger("Land");
            StartCoroutine("StringDropping");
        }
        else if(animInfo.tagHash == Animator.StringToHash("Attack") ||
            animInfo.tagHash == Animator.StringToHash("AttackMode") ||
            animInfo.tagHash == Animator.StringToHash("Land") ||
            animInfo.tagHash == Animator.StringToHash("Dropping"))
        {
            return;
        }

        else
        {
            return;
        }
    }

    public void ResetRoutine()
    {
        if (animInfo.tagHash == Animator.StringToHash("Dropping"))
        {
            StopAllCoroutines();
            isDropping = false;
            isClimbing = true;
            isAttacking = false;
            anim.ResetTrigger("Land");
            StartCoroutine("StringClimbing");
        }
        else if(animInfo.tagHash == Animator.StringToHash("Land"))
        {
            StopAllCoroutines();
            retractPos = webString.transform.position.y;
            anim.ResetTrigger("Land");
            isDropping = false;
            isAttacking = false;
        }
        else if(animInfo.tagHash == Animator.StringToHash("AttackMode") ||
            animInfo.tagHash == Animator.StringToHash("Attack"))
        {
            StopAllCoroutines();
            anim.ResetTrigger("Land");
            isDropping = false;
            isAttacking = false;
        }
        else
        {
            return;
        }
        
    }
    void SetRigidBody()
    {
        if (animInfo.tagHash == Animator.StringToHash("AttackMode"))  
        {
            rb.isKinematic = false;
            anim.ResetTrigger("Land");
        }
        if (animInfo.tagHash == Animator.StringToHash("LineSquirt"))
        {
            rb.isKinematic = true;
            //anim.ResetTrigger("Land");
        }
        if (animInfo.tagHash == Animator.StringToHash("Die"))
        {
            rb.isKinematic = false;
            isAttacking = false;
            isClimbing = false;
            isDropping = false;
            webString.SetActive(false);
            bottomCollider.SetActive(false);
            anim.ResetTrigger("Land");
            StopAllCoroutines();
        }
    }

    //WALK
    public override void WalkRoutine()
    {
        if(animInfo.tagHash == Animator.StringToHash("AttackMode"))
        {
            //rbVelocity = new Vector2(Mathf.PingPong(Time.time * , 1), rb.velocity.y);
            rb.velocity = new Vector2(Mathf.SmoothStep(minX, maxX, walkSpeed),rb.velocity.y );
            walkSpeed = Mathf.PingPong(Time.time * speed, 1);

        }
        if(animInfo.tagHash == Animator.StringToHash("Attack"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }
    }

    void FacePlayer()
    {
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
            if (movingLeft != true)
            {
                //rbVelocity = new Vector2(transform.localScale.x * speed, rb.velocity.y);
            }

        }
        else
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
            if (movingLeft == true)
            {
                //rbVelocity = new Vector2(transform.localScale.x * speed, rb.velocity.y);
            }
        }
    }

    //JUMPING
    public override void Jump()
    {
        if (isGrounded != false)
        {
            //rbVelocity = new Vector2(0, rb.velocity.y);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void AttackRaycast()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + rayBufferX, transform.position.y + rayBufferY), Vector2.right, 10, playerLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - rayBufferX, transform.position.y + rayBufferY), -Vector2.right, 10, playerLayer);

        Debug.DrawRay(new Vector2(transform.position.x + rayBufferX, transform.position.y + rayBufferY), Vector2.right * 10, Color.blue);
        Debug.DrawRay(new Vector2(transform.position.x - rayBufferX, transform.position.y + rayBufferY), -Vector2.right * 10, Color.red);
        if (hitRight.collider == playerCollider || hitLeft.collider == playerCollider)
        {
            if (shooting == false)
            {
                shooting = true;
                Jump();
                //Debug.Log("HIT");
                
            }

        }
        else
        {
            shooting = false;
            
        }
    }

    //WEBSTRING

    IEnumerator StringDropping()
    {
        //Debug.Log("!String Dropping...");
        float dropPosYMulti = webString.transform.position.y;
        float dropScaleYMulti = webString.transform.localScale.y;

        while (isDropping == true)
        {
            dropPosYMulti -= dropPosY * Time.deltaTime;
            dropScaleYMulti += dropScaleY * Time.deltaTime;

            webString.transform.position = new Vector3(webString.transform.position.x, dropPosYMulti, 0);
            webString.transform.localScale = new Vector3(webString.transform.localScale.x, dropScaleYMulti, 1);
            yield return null;
        }
        //Debug.Log("**String Dropped**");
    }

    IEnumerator StringClimbing()
    {
        //Debug.Log("!String Climbing");
        float climbPosYMulti = webString.transform.position.y;
        float climbScaleYMulti = webString.transform.localScale.y;

        while (isClimbing == true)
        {
            climbPosYMulti += climbPosY * Time.deltaTime;
            climbScaleYMulti -= climbScaleY * Time.deltaTime;

            webString.transform.position = new Vector3(webString.transform.position.x, climbPosYMulti, 0);
            webString.transform.localScale = new Vector3(webString.transform.localScale.x, climbScaleYMulti, 1);
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, climbTargetPos, 0);
        webString.transform.localScale = new Vector3(webString.transform.localScale.x, webStringStartScaleY, 0);
        webString.transform.position = new Vector3(webString.transform.position.x, webString.transform.position.y, 1);
        //Debug.Log("**String Climbed**");
    }

    public void ShootString()
    {
        //shooting = true;
        StartCoroutine("Shooting");
    }

    bool IsShot()
    {
        if (webString.transform.localScale.y == shootPos)
        {
            return  true;
        }
        else
        {
            return false;
        }
    }


    IEnumerator Shooting()
    {
        //Debug.Log("!String Shooting...");
        shootPos = shootTargetScaleY;
        if(reachedEnd == true)
        {
            webString.transform.position = new Vector3(webString.transform.position.x, webStringEndPosY, 0);
            webString.transform.localScale = new Vector3(webString.transform.localScale.x, webStringEndScaleY, 1);
        }    
        while (IsShot() == false)
        {
            
            webString.transform.position = Vector3.MoveTowards(webString.transform.position, new Vector3(webString.transform.position.x, shootTargetPosY, 0), shootSpeed * Time.deltaTime);
            webString.transform.localScale = Vector3.MoveTowards(webString.transform.localScale, new Vector3(webString.transform.localScale.x, shootTargetScaleY, 1), shootScaleSpeed * Time.deltaTime);
            yield return new WaitForSeconds(.01f);
        }
        //webString.transform.position = new Vector3(webString.transform.position.x, shootTargetPosY, 0);
        //webString.transform.localScale = new Vector3(webString.transform.localScale.x, shootTargetScaleY, 0);
        //Debug.Log("**String Shot**");
        isClimbing = true;
        StartCoroutine("StringClimbing");
    }

    bool IsRetracted()
    {
        if(webString.transform.position.y == retractPos)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator StringRetract()
    {
        
        transform.position = new Vector2(transform.position.x, landPosX);
        retractPos = retractPosY;
        //Debug.Log("!String Retracting...");
        while (IsRetracted() == false )
        {

            webString.transform.position = Vector3.MoveTowards(webString.transform.position, new Vector3(webString.transform.position.x, retractPosY, 0), retractPosSpeed * Time.deltaTime);
            webString.transform.localScale = Vector3.MoveTowards(webString.transform.localScale, new Vector3(webString.transform.localScale.x, retractScaleY, 1), retractScaleSpeed * Time.deltaTime);
            yield return new WaitForSeconds(.01f);
        }
        //Debug.Log("**String Retracted**");
        
        webString.transform.localScale = new Vector3(webString.transform.localScale.x, retractScaleY, 1);
        isAttacking = true;
        if(reachedEnd == false)
        {
            webStringEndPosY = webString.transform.position.y;
            webStringEndScaleY = webString.transform.localScale.y;
        }
        else
        {
            webString.transform.position = new Vector3(webString.transform.position.x, webStringEndPosY, 0);
            webString.transform.localScale = new Vector3(webString.transform.localScale.x, webStringEndScaleY, 1);
        }
    }
    
    //BULLET

    public override void Shoot()
    {
        if (inLimbo != true || GameController.freezeAll != true)
        {
            bulletPrefab = Instantiate(bullet, shotSpawn.position, Quaternion.identity, transform);
            StartCoroutine("ParentDetach");
        }
    }

    IEnumerator ParentDetach()
    {
        yield return null;
        bulletPrefab.transform.parent = null;
    }
}
