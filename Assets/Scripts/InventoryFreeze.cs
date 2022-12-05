using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryFreeze : MonoBehaviour
{
    Button inventory;
    public float time = 4;

    private void Awake()
    {
        inventory = GetComponent<Button>();
    }

    public void DeactivateButton()
    {
        inventory.interactable = false;
        StartCoroutine("ReactivateButton");
    }

    IEnumerator ReactivateButton()
    {
        yield return new WaitForSeconds(time);
        inventory.interactable = true;
    }
}
