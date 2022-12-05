using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToArea : MonoBehaviour
{
    public string sceneName;

    //int sceneCount;
    //public string[] scenes;

    public Vector2 playerPosition;
    public float xScale;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PhysicalCollider");
        /*sceneCount = SceneManager.sceneCountInBuildSettings;
        scenes = new string[sceneCount];
        for(int i = 0; i < sceneCount; i++)
        {
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            GameController.returnToAreaPosition = playerPosition;
            GameController.returnToAreaXScale = xScale;
            SceneManager.LoadScene(sceneName);
        }

    }


}
