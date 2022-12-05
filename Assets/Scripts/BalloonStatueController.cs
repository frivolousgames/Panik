using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonStatueController : MonoBehaviour
{
    GameObject player;

    public static bool onBalloonStatue;

    SpriteRenderer sr;
    Color startColor;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        onBalloonStatue = false;
        startColor = sr.color;
    }

    private void Update()
    {
        //Debug.Log("Balloon Usable: " + GameController.balloonUsable);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            onBalloonStatue = true;
            sr.color = Color.white;
            GameController.balloonUsable = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            onBalloonStatue = true;
            sr.color = Color.white;
            GameController.balloonUsable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            onBalloonStatue = false;
            sr.color = startColor;
            GameController.balloonUsable = false;
        }
    }
}
