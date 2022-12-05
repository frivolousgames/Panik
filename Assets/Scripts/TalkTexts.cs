using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTexts : MonoBehaviour
{
    public static string oldLadyRock_01;
    public static string villagerManRock_01;
    public static string cowRock_01;
    public static string boyBlockadeRock_01;
    public static string villagerManCasino_01;
    public static string villagerManRock_02;

    //Trapped Miner
    


    bool casinoLetter;
    bool casinoOpen;

    public static List<string> genericSpeech = new List<string>();
    string generic_01;
    string generic_02;
    string generic_03;
    string generic_04;
    string generic_05;
    string generic_06;
    string generic_07;
    string generic_08;

    private void Awake()
    {
        generic_01 = "Hello Comrade!\nBeautiful day isn't it?";
        generic_02 = "Good day Comrade!";
        generic_03 = "Our humble village welcomes you Comrade!";
        generic_04 = "Sorry Comrade I cannot talk I have business to attend to";
        generic_05 = "The ghost of Lenin visits me in my dreams it is true!";
        generic_06 = "I have not seen your face around before Comrade";
        generic_07 = "My life is quite boring Comrade but I don't mind";
        generic_08 = "My diaper is very full\nPlease help me change it comrade!";

        genericSpeech.Add(generic_01);
        genericSpeech.Add(generic_02);
        genericSpeech.Add(generic_03);
        genericSpeech.Add(generic_04);
        genericSpeech.Add(generic_05);
        genericSpeech.Add(generic_06);
        genericSpeech.Add(generic_07);
        genericSpeech.Add(generic_08);

        oldLadyRock_01 = genericSpeech[Random.Range(0, genericSpeech.Count)];

        villagerManRock_01 = "Go to the shop at the end of town comrade.\nMy brother Uri will treat you well!";

        cowRock_01 = "MOO!";

        villagerManRock_02 = "There is an old cave by the cliff door that only the gulls can reach.";

        boyBlockadeRock_01 = "My uncle Ivan is a bully.\nHe stole my favorite hat.";
        villagerManCasino_01 = "There is no illegal conduct happening here comrade!\nWho told you such a thing?!";
       
    }

    private void Update()
    {
        if (GameController.hatUsed == true && PlayerPrefs.GetString("HatCompleted", "False") == "False")
        {
            boyBlockadeRock_01 = "My hat!\nThank you comrade!\nI hope you taught Ivan a lesson";
        }
        else if (PlayerPrefs.GetString("HatCompleted", "False") == "True")
        {
            boyBlockadeRock_01 = "Thanks again, comrade!";
        }
        else
        {
            boyBlockadeRock_01 = "My uncle Ivan is a bully.\nHe stole my favorite hat.";
        }



        if (GameController.chipUsed == true && PlayerPrefs.GetString("Chip Completed", "False") == "False")
        {
            villagerManCasino_01 = "One of my chips!\nMy apologies comrade\nI suppose I can trust you";
            
        }
        else if (PlayerPrefs.GetString("Chip Completed", "False") == "True")
        {
            villagerManCasino_01 = "Choose Your Game:\n\n\n";
        }
        else
        {
            villagerManCasino_01 = "There is no illegal conduct happening here comrade!\nWho told you such a thing?!";
        }
    }

    
}
