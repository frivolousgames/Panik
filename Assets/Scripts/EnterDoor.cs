using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    string sceneEntering;

    public void LoadScene()
    {
        sceneEntering = SetDoorSceneName.setSceneName;
        if (sceneEntering != null)
        {
            SceneManager.LoadScene(sceneEntering);
        }
        
        //Debug.Log("Entered House");
    }
}
