using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneButton : MonoBehaviour
{
    public string sceneName;

    public Vector2 playerPosition;
    public float xScale;

    public void LoadLevel()
    {
        GameController.returnToAreaPosition = playerPosition;
        GameController.returnToAreaXScale = xScale;
        SceneManager.LoadScene(sceneName);
    }
}
