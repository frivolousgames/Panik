using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreLayer : MonoBehaviour
{
    LayerMask enemy;
    LayerMask enemyBullet;

    private void Awake()
    {
        enemy = LayerMask.NameToLayer("Enemy");
        enemyBullet = LayerMask.NameToLayer("EnemyBullet");
    }

    private void Update()
    {
        Physics2D.IgnoreLayerCollision(10, 11);
    }
}
