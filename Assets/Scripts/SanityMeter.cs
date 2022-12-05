using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class SanityMeter : MonoBehaviour
{
    Slider sanityMeter;
    public static int sanityAmount = 0;

    public Image fillColor;
    public float blinkSpeed;
    Color blinkColor;
    bool readyToGo;

    public GameObject whiteFader;
    GameObject canvas;

    CinemachineVirtualCamera cam;
    public float zoomTime;

    string level;

    private void Awake()
    {
        sanityAmount = (int)GameController.sanityAmount;
        sanityMeter = GetComponent<Slider>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        cam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        sanityMeter.value = sanityAmount;
        Glow();
        //Debug.Log("Sanity Level " + sanityAmount);
        //Debug.Log("Ready " + readyToGo);
        if(sanityAmount > 100)
        {
            sanityAmount = 100;
        }
    }

    void Glow()
    {
        if(sanityAmount == 100)
        {
            blinkColor = new Color( fillColor.color.r, fillColor.color.g, fillColor.color.b, Mathf.PingPong(blinkSpeed * Time.time, 1f));
            fillColor.color = blinkColor;
            readyToGo = true;
        }
    }

    public void SendToSanity()
    {
        if(readyToGo != false)
        {
            sanityAmount = 0;
            Debug.Log("GO TIME");
            Instantiate(whiteFader, canvas.transform);
            level = GameController.currentScene;
            StartCoroutine("DeathZoom");
            readyToGo = false;
        }
        
    }
    bool Zoomed()
    {
        if (cam.m_Lens.OrthographicSize < 2)
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }
    IEnumerator DeathZoom()
    {
        while (Zoomed() == false)
        {
            cam.m_Lens.OrthographicSize -= zoomTime * Time.deltaTime;
            yield return null;
        }
        LoadSanityLevel(level);
    }
    void LoadSanityLevel(string level)
    {
        switch (level)
        {
            case "Level_01":
                SceneManager.LoadScene("Village_Rock_01");
                break;

            case null:
                break;

            default:
                break;
        }
    }
}
