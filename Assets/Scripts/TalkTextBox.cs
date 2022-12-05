using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTextBox : MonoBehaviour
{
    public GameObject talkButton;
    public GameObject blocker;

    private void OnEnable()
    {
        talkButton.SetActive(false);
        blocker.SetActive(true);
    }

    private void OnDisable()
    {
        if(TriggerEnterButton.nearTalker == true)
        {
            talkButton.SetActive(true);
        }
        else
        {
            talkButton.SetActive(false);
        }
        blocker.SetActive(false);

    }

    public void DeactivateBox()
    {
        gameObject.SetActive(false);
    }
}
