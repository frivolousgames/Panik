using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    public GameObject tooltip;

    public void PopUp()
    {
        tooltip.SetActive(true);
    }

    public void Close()
    {
        tooltip.SetActive(false);
    }
}
