using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenInventoryScreen : MonoBehaviour
{

    public void LoadScene()
    {
        if(SceneManager.GetSceneByName("Inventory").isLoaded == false)
        {
            SceneManager.LoadScene("Inventory", LoadSceneMode.Additive);

        }
    }
}