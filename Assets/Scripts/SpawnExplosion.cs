using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExplosion : MonoBehaviour
{
    public GameObject explosion;
    public GameObject axe;
    GameObject exPrefab;
    private void OnDestroy()
    {
        ExplosionOptions(gameObject.name);
    }

    void ExplosionOptions(string name)
    {
        switch(name)
        {
            case "Bullet_Fire_Med":
                exPrefab = Instantiate(explosion, transform.position, Quaternion.identity, null);
                ParticleSystem.MinMaxGradient newColor = exPrefab.GetComponentInChildren<ParticleSystem.MainModule>().startColor;
                Color orange = new Color(255, 140, 0);
                newColor = new ParticleSystem.MinMaxGradient(orange);
                break;
            case "Bullet_Axe_Med":
                exPrefab = Instantiate(axe, transform.position, Quaternion.identity, null);
                exPrefab.transform.localScale = transform.localScale;
                break;
            case null:
                Instantiate(explosion, transform.position, Quaternion.identity, null);
                break;
            default:
                Instantiate(explosion, transform.position, Quaternion.identity, null);
                break;
        }
    }
}
