using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueMenu : MonoBehaviour
{
    public void Retry()
    {
        StartCoroutine("LoadWait");
      
    }

    IEnumerator LoadWait()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Level_01");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
