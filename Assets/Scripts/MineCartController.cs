using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MineCartController : VehicleController
{
    bool starting;
    GameObject[] obstacles;
    public GameObject explosion;
    //float rotationZ;
    //Vector3 currentEulerAngles;

    public float zMax;
    public float zMin;

    //LERP
    Quaternion rot;
    public float rotSpeed = 1;
    public float rotGroundSpeed = 2;
    bool lerping;
    //SLAM
    /*public float slamSpeed;
    float polarity;*/

    //DIE
    public static bool dead;
    public UnityEvent die;

    public GameObject deathZone;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rot = transform.rotation;
        dead = false;
        starting = true;
        StartCoroutine("StartDelay");
        lerping = false;
    }

    private void Update()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Enemy");
        
        //Debug.Log("isLerping: " + lerping);
        //Debug.Log("Rot: " + rotationZ);
        //Debug.Log("rot: " + transform.rotation.z);
        //Debug.Log("Local: " + transform.rotation.z);
        //rotationZ = Mathf.Clamp(transform.rotation.z, -.37f, .37f);
        //transform.rotation = new Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, rotationZ);
        //transform.localEulerAngles = new Vector3(0,0, rotationZ);
        
        //Debug.Log(transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(transform.rotation.normalized.z, zMin, zMax)));
        
        //float angle = transform.localEulerAngles.z;
        //angle = Mathf.Clamp(NormalizeAngle(angle), zMin, zMax);
        //transform.rotation = Quaternion.Euler(0.0f, 0.0f,angle);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.IsTouchingLayers(groundCollider, groundLayer);
        CheckOrientation();
        Lerping();
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(.4f);
        starting = false;
    }

    void CheckOrientation()
    {
        if(isJumping == false && isGrounded == true)
        {
            if (transform.rotation.z < 0)
            {
                rb.velocity = new Vector3(1 * speed, -1 * speed);
            }
            else if(transform.rotation.z > 10)
            {
                rb.velocity = Vector3.right * speed * 1.5f;
            }
            else
            {
                rb.velocity = Vector3.right * speed;
            }
            //Debug.Log("DRIVING");
        }
        else
        {
            //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            
        }
    }

    public override void Jump()
    {
        if(starting == false)
        {
            if (isGrounded == true)
            {
                isJumping = true;
                //rb.freezeRotation = true;
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                //StartCoroutine("JumpRoutine");
            }
            //if(transform.rotation.z < )
        }
    }

    void Lerping()
    {
        if(isGrounded == false)
        {
            
            //transform.rotation = new Quaternion(0, 0, Mathf.Clamp(transform.rotation.z, zMin, zMax), 1f);
            if(transform.rotation != rot)
            {
                rb.MoveRotation(new Quaternion(rot.x, rot.y, Mathf.LerpAngle(transform.rotation.z, rot.z, Time.deltaTime * rotSpeed), 1f));
            }
        }
    }
    //SLAM
    /*public override void SlamWheelOnLanding()
    {
        if(isGrounded == true)
        {
            if (WheelSlammer.wheelName == "back wheel")
            {
                polarity = 1;
            }
            else
            {
                polarity = -1;
            }
            StartCoroutine(SlamRoutine());
        } 
    }

    IEnumerator SlamRoutine()
    {
        while(WheelSlammer.bothLanded == false)
        {
            transform.Rotate(new Vector3(0f, 0f, polarity * slamSpeed));
            yield return null;
        }
        StopAllCoroutines();
    }
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(obstacles != null)
        {
            foreach (GameObject o in obstacles)
            {
                if (other.gameObject == o)
                {
                    if(dead != true)
                    {
                        Instantiate(explosion, transform.position, Quaternion.identity, null);
                        dead = true;
                        die.Invoke();
                        Debug.Log("DEAD");
                        Destroy(o);
                        Destroy(gameObject);
                    } 
                }
            }
        }

        if(other.gameObject.name == "Ground")
        {
            if (isGrounded == false)
            {
                isJumping = false;
                //StartCoroutine("ResetGravity");
                //lerping = false;
                //rb.freezeRotation = false;
                //Debug.Log("LANDED");
            }
        }

        if(other.gameObject == deathZone)
        {
            dead = true;
            die.Invoke();
            Destroy(gameObject);
        }
    }
}
