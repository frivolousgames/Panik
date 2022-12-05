using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySceneController : MonoBehaviour
{
    int enemies;
    public string sceneName;
    private void Awake()
    {
        enemies = transform.childCount;
    }
    private void Update()
    {
        if(enemies < 1)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}
