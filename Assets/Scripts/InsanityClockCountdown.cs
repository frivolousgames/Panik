using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class InsanityClockCountdown : MonoBehaviour
{
    Text timerText;
    float timerStartTime;
    int timerTime;
    bool backToInsanity;
    bool timeUp;

    CinemachineVirtualCamera cam;
    public float tiltSpeed;
    public float zoomSpeed;

    public GameObject spiral;
    public GameObject blackFade;
    public float fadeWait;
    public Transform canvas;
    public float colorSpeed;
    

    private void Awake()
    {
        timeUp = false;
        //PlayerPrefs.SetFloat("InsanityTimer", 10f);
        timerText = GetComponent<Text>();
        timerStartTime = PlayerPrefs.GetFloat("InsanityTimer", 120f);
        timerText.text = timerStartTime.ToString();
        cam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        InsanityComing();
        if (GameController.freezeAll != true)
        {
            if (timeUp != true)
            {
                timerStartTime -= Time.deltaTime;
                PlayerPrefs.SetFloat("InsanityTimer", timerStartTime);
                timerTime = (int)timerStartTime;
                timerText.text = timerTime.ToString();
            }
            else
            {
                timerText.text = "Goodbye";
                PlayerPrefs.SetFloat("InsanityTimer", 120f);
            }
        }
        
        
        if(timerTime < 10)
        {
            timerText.color = Color.magenta;
        }
        if(timerTime == 0)
        {
           Color timerColor = new Color(timerText.color.r, timerText.color.g, timerText.color.b, Mathf.PingPong(colorSpeed * Time.time, 1));
            timerText.color = timerColor;
        }
        if(timeUp == true)
        {
            if(backToInsanity == false)
            {
                
                StartCoroutine("BackToInsanity");
                StartCoroutine("BlackFader");
                spiral.SetActive(true);
                backToInsanity = true;
            }
            
        }
        //Debug.Log("Freeze " + timeUp);
        //Debug.Log("Time " + timerTime);
        //Debug.Log("Saved Time " + PlayerPrefs.GetFloat("InsanityTimer", 120f));
    }
    IEnumerator BackToInsanity()
    {
        while(Spinning() == true)
        {
            cam.m_Lens.Dutch += tiltSpeed * Time.deltaTime;
            cam.m_Lens.OrthographicSize -= zoomSpeed * Time.deltaTime;
            yield return null;
        }

    }
    IEnumerator BlackFader()
    {
        yield return new WaitForSeconds(fadeWait);
        GameObject black = Instantiate(blackFade, canvas);
        black.SetActive(true);
    }

    bool Spinning()
    {
        if(cam.m_Lens.Dutch < 180)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool Zoomed()
    {
        if(cam.m_Lens.OrthographicSize < 2)
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }
    void LoadSaneLevel()
    {
        //SceneManager.LoadLevel(GameController.saneLevel);
    }

    void InsanityComing()
    {
        if(timerTime < 0) 
        {
            timeUp = true;          
        }
    }

    /*public void Freeze()
    {
        freeze = true;
    }

    public void UnFreeze()
    {
        freeze = false;
    }*/




}
