using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCasinoGames : MonoBehaviour
{
    public void LoadBabushka()
    {
        SceneManager.LoadScene("Old_Lady_Race_Rock");
    }

    public void LoadCircle()
    {
        SceneManager.LoadScene("Circle_of_Fate_Rock");
    }
}
