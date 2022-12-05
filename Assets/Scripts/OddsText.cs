using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OddsText : MonoBehaviour
{
    public GameObject oddsPanel;

    public void SetActive()
    {
        oddsPanel.SetActive(true);
    }

    public void Deactivate()
    {
        oddsPanel.SetActive(false);

    }
}
