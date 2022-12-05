using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDoorSceneName : MonoBehaviour
{
    public string sceneName;
    public static string setSceneName;
    GameObject player;

    private void Awake()
    {
        
        setSceneName = null;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //Debug.Log("SceneName " + setSceneName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            setSceneName = sceneName;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            setSceneName = null;
        }
    }
}
