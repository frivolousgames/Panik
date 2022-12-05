using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextLevel : MonoBehaviour
{

    string lastScene;
    string levelName;

    private void Awake()
    {
        levelName = SceneManager.GetActiveScene().name;
    }

    private void Start()
    {
        
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level_01");
    }
    
    public void LoadLastLevel()
    {
        FindLastLevel(levelName);
        SceneManager.LoadScene(lastScene);
    }

    void FindLastLevel(string levelName)
    {
        switch (levelName)
        {
            case "Old_Lady_Race_Rock":
                lastScene = "Cabin_Inside_01_Rock";
                break;
            case "Circle_of_Fate_Rock":
                lastScene = "Cabin_Inside_01_Rock";
                break;
            case null:
                lastScene = "Level_01";
                break;
            default:
                lastScene = "Level_01";
                break;
        }
    }

    /*public void LoadLevel()
    {
        if(GameManager.ContinueCheck() != false)
        {
            SceneManager.LoadScene("ContinueNewGame", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene("ContinueNewGame", LoadSceneMode.Additive);
            //SceneManager.LoadScene("Beginning");
        }
        
    }*/

    
}

