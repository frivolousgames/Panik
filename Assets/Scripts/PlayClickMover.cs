using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayClickMover : MonoBehaviour
{
    Button playButton;
    Animator anim;

    private void Awake()
    {
        playButton = GetComponent<Button>();
        anim = GetComponent<Animator>();
    }

    public void PlayClicked()
    {
        playButton.interactable = false;
        anim.SetTrigger("Clicked");
    }
}
