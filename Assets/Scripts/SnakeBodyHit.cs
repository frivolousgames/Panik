using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyHit : MonoBehaviour
{
    public void BodyHit()
    {
        GetComponent<EnemyHealth>().health -= 5;
    }
}
