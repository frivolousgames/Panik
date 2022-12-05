using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class RailDeathController : MonoBehaviour
{
    private bool dead;
    public float zoomTime;
    private float deathZoomWait;
    private bool zoomed;
    public GameObject deathPanel;
    public CinemachineVirtualCamera deathCam;
    public GameObject shakeCam;
    Image deathScreen;
    Color color;
    public float colorAdd;

    public GameObject endText;

    private void Awake()
    {
        deathScreen = deathPanel.GetComponent<Image>();
    }

    private void Start()
    {
        deathPanel.SetActive(false);
    }

    private void Update()
    {
        //Debug.Log(deathScreen.color.a);
    }

    //DIE
    public void Dead()
    {
        if (MineCartController.dead == true)
        {
            StartCoroutine("DieWait");
        }
    }

    IEnumerator DieWait()
    {
        yield return new WaitForSeconds(1f);
        deathPanel.SetActive(true);
        //StartCoroutine("DeathZoom");
        StartCoroutine("FadeWait");
        //dead = true;
    }

    IEnumerator DeathZoom()
    {
        if (!shakeCam.activeInHierarchy)
        {
            if (!deathCam.gameObject.activeInHierarchy)
            {
                deathCam.gameObject.SetActive(true);
            }
            while (Zoomed() == false)
            {
                deathCam.m_Lens.OrthographicSize -= zoomTime * Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            yield return null;
        }
    }

    IEnumerator FadeWait()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine("DeathFade");
        endText.SetActive(true);
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
        if (deathScreen.color.a > .5f)
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
        if (deathCam.m_Lens.OrthographicSize < 2)
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
        if (Faded() == true)
        {
            //SceneManager.LoadScene("Continue");
        }
    }
}
