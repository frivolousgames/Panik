using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveScene01 : MonoBehaviour
{
    public GameObject bearCam;
    public GameObject playerZoomCam;
    public GameObject bearTrigger;
    public GameObject bear;
    public GameObject doorSwitcher;
    public GameObject playerCam;
    public GameObject bearLifeMeter;
    public GameObject freezeController;
    public GameObject blocker;

    private void Awake()
    {
        PlayerPrefs.SetString("Hat", "False");
        
    }
    private void Start()
    {
        if (PlayerPrefs.GetString("Hat", "False") != "True")
        {
            freezeController.SetActive(true);
        }
    }

    private void Update()
    {
        if(PlayerPrefs.GetString("Hat", "False") == "True")
        {
            bearCam.SetActive(false);
            playerZoomCam.SetActive(false);
            bearTrigger.SetActive(false);
            doorSwitcher.SetActive(true);
            playerCam.SetActive(true);
            if(bearLifeMeter != null)
            {
                bearLifeMeter.SetActive(false);
            }
            freezeController.SetActive(false);
            blocker.SetActive(false);
            if (bear != null)
            {
                bear.SetActive(false);
            }
            else
            {
                freezeController.SetActive(true);
            }
        }
    }
}
