using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossCamTrigger : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject playerZoomCam;
    public GameObject bossCam;

    public UnityEvent trigger;

    private void Awake()
    {
        trigger.Invoke();
        StartCoroutine("BeginCamSwitch");
    }

    IEnumerator BeginCamSwitch()
    {
        yield return new WaitForSeconds(.7f);
        bossCam.SetActive(true);
        playerZoomCam.SetActive(false);
        StartCoroutine("SetPlayerCam");

    }

    IEnumerator SetPlayerCam()
    {
        yield return new WaitForSeconds(4f);
        playerCam.SetActive(true);
        bossCam.SetActive(false);
    }
}
