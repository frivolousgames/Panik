using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RailSwitchController : MonoBehaviour
{
    public GameObject shaft;
    Collider2D col;

    GameObject player;
    GameObject[] bullet;

    public float rotSpeed;

    public UnityEvent rotate;

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        bullet = GameObject.FindGameObjectsWithTag("Default Bullet");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(bullet != null)
        {
            foreach (GameObject b in bullet)
            {
                if (other.gameObject == b)
                {
                    col.enabled = false;
                    rotate.Invoke();
                }
            }
        }
    }
}
