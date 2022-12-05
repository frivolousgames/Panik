using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateBuyScreen : MonoBehaviour
{
    Animator anim;

    bool inventoryTrue;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    public void Contract()
    {
        anim.SetTrigger("Contract");
    }
    public void CloseScene()
    {
        GetScenes();
        if (inventoryTrue == true)
        {
            SceneManager.UnloadSceneAsync("Inventory");
        }
        else
        {
            SceneManager.UnloadSceneAsync(GameController.currentScene);
        }
    }


    public void LoadNextScene()
    {
        switch (GameController.currentScene)
        {
            case "Buy_Screen_01_Rock":
                SceneManager.LoadScene("Cabin_Inside_02_Rock");
                break;
            default:
                break;


        }
    }
    void GetScenes()
    {
        int countLoaded = SceneManager.sceneCount;
        Scene[] loadedScenes = new Scene[countLoaded];

        for (int i = 0; i < countLoaded; i++)
        {
            loadedScenes[i] = SceneManager.GetSceneAt(i);
        }
        foreach(Scene scene in loadedScenes)
        {
            if(scene.name == "Inventory")
            {
                inventoryTrue = true;
            }
        }
    }
}
