using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTalkText : MonoBehaviour
{
    GameObject speaker;
    string myName;
    
    public GameObject talkTextBox;
    string textBlurb;
    

    

    private void Awake()
    {
        //speaker = SetTalkTextName.myName;
        //myName = speaker.name; 
    }
    private void Update()
    {
        speaker = SetTalkTextName.myName;
        myName = speaker.name;
        //Debug.Log("myname " + myName.ToString());
    }

    void SetTalkText(string name)
    {
            switch (name)
            {
                case "OldLadyRock_01":
                    textBlurb = TalkTexts.genericSpeech[Random.Range(0, TalkTexts.genericSpeech.Count)];
                    break;
                 case "Villager_Man_Rock_01":
                    textBlurb = TalkTexts.villagerManRock_01;
                    break;
            case "Villager_Man_Rock_02":
                textBlurb = TalkTexts.villagerManRock_02;
                break;
            case "Cow_Rock_01":
                    textBlurb = TalkTexts.cowRock_01;
                    break;
                case "Villager_Boy_Rock_01":
                    textBlurb = TalkTexts.boyBlockadeRock_01;
                    break;
                case "Villager_Man_Casino_01":
                    textBlurb = TalkTexts.villagerManCasino_01;
                    break;
            case null:
                    textBlurb = "Null";
                    break;
                default:
                    textBlurb = "Hello Comrade!";
                    break;
            }
    }

    public void SpawnText()
    {
      
        SetTalkText(myName);
        //if(!talkTextBox.activeInHierarchy)
        //{
            talkTextBox.SetActive(true);
            talkTextBox.GetComponentInChildren<Text>().text = textBlurb;
            
        //}
        //GameObject.FindGameObjectWithTag("EnterHouseButton").GetComponentInChildren<Text>().enabled = false;
        //gameObject.SetActive(false);
    }
    
}
