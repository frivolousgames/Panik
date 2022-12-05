using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvalancheController : MonoBehaviour
{
    //Cams
    public GameObject shakeCam;
    public GameObject doorCam;
    public GameObject bouldersCam;
    public GameObject minerCam;
    public GameObject zoomCam;
    public GameObject dynamiteCam01;
    public GameObject dynamiteCam02;
    public GameObject dynamiteCam03;
    public GameObject redXCam;
    public GameObject controlRoomCam;
    //Emitters
    public GameObject smokeEmitter;
    public GameObject dustEmitter;
    public GameObject pebbleEmitter;

    public GameObject whiteFader;
    public GameObject boulders;
    public GameObject textBox;

    GameObject player;

    public Text trappedMinerText;
    string trappedSpeech;
    string tm_A = "There was a cave in!\nThe falling boulders have me pinned!";
    string tm_B = "Oh the pain!\nIt's immeasurable!";
    string tm_C = "I fear my genitals are destroyed beyond repair!";
    string tm_D = "This is bad news comrade\nI have a wife and 4 mistresses to please";
    string tm_E = "My life has collapsed into rubble much like the walls of this cave!";
    string tm_F = "Anyways...";
    string tm_G = "You must collect 3 bundles of dynamite from deep inside the cave";
    string tm_H = "And place them on the red \"X\"";
    string tm_I = "Then head to the control room and detonate the dynamite";
    string tm_J = "Hopefully the explosion will be powerful enough to free me...";
    string tm_K = "And my ruined genitals";
    string tm_L = "Please move quickly comrade for I have many errands to run today";

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerController.isFrozen = true;
        trappedSpeech = "I am trapped comrade!\nPlease help me!";
        trappedMinerText.text = trappedSpeech;
        StartCoroutine(Avalanche());
        
    }

    private void Update()
    {
        trappedMinerText.text = trappedSpeech;
    }

    IEnumerator Avalanche()
    {
        zoomCam.SetActive(true);
        yield return new WaitForSeconds(3f);
        shakeCam.SetActive(true);
        yield return new WaitForSeconds(1f);
        dustEmitter.SetActive(true);
        pebbleEmitter.SetActive(true);
        yield return new WaitForSeconds(2f);
        whiteFader.SetActive(true);
        yield return new WaitForSeconds(1.6f);
        boulders.SetActive(true);
        smokeEmitter.SetActive(true);
        shakeCam.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        doorCam.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        doorCam.SetActive(false);
        bouldersCam.SetActive(true);
        yield return new WaitForSeconds(2f);
        bouldersCam.SetActive(false);
        minerCam.SetActive(true);
        yield return new WaitForSeconds(3f);
        textBox.SetActive(true);
    }

    public void TrappedMinerSpeech()
    {
        if (trappedSpeech == "I am trapped comrade!\nPlease help me!")
        {
            trappedSpeech = tm_A;
        }
        else if (trappedSpeech == tm_A)
        {
            trappedSpeech = tm_B;
        }
        else if (trappedSpeech == tm_B)
        {
            trappedSpeech = tm_C;
        }
        else if (trappedSpeech == tm_C)
        {
            trappedSpeech = tm_D;
        }
        else if (trappedSpeech == tm_D)
        {
            trappedSpeech = tm_E;
        }
        else if (trappedSpeech == tm_E)
        {
            trappedSpeech = tm_F;
        }
        else if (trappedSpeech == tm_F)
        {
            trappedSpeech = tm_G;
        }
        else if (trappedSpeech == tm_G)
        {
            trappedSpeech = tm_H;
        }
        else if (trappedSpeech == tm_H)
        {
            trappedSpeech = tm_I;
        }
        else if (trappedSpeech == tm_I)
        {
            trappedSpeech = tm_J;
        }
        else if (trappedSpeech == tm_J)
        {
            trappedSpeech = tm_K;
        }
        else if (trappedSpeech == tm_K)
        {
            trappedSpeech = tm_L;
        }
    }
}
