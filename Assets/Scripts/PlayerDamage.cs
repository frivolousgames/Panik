using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public static int lightDamage;
    public static int medDamage;
    public static int heavyDamage;
    public static int contact;

    private void Awake()
    {
        contact = 2;
        lightDamage = 5;
        medDamage = 10;
        heavyDamage = 15;

       
    }
}
