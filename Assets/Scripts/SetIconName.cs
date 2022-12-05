using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetIconName : MonoBehaviour
{
    Text iconName;

    private void Awake()
    {
        iconName = GetComponent<Text>();
        iconName.text = transform.parent.name;
    }
}
