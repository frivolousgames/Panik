using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour
{
    GameObject[] walls;
    Transform parentTrans;

    public GameObject explosion;
    public GameObject axe;
    GameObject exPrefab;

    private void Awake()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
    }
    private void Update()
    {
        //Debug.Log(gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("PlayerHitCollider"))
        {
            parentTrans = other.gameObject.transform;
            ExplosionOptions(gameObject.name);
            Destroy(gameObject);
        }
        foreach(GameObject wall in walls)
        {
            if(other.gameObject == wall)
            {
                ExplosionOptions(gameObject.name);
                Destroy(gameObject);
            }
        }
    }

    void ExplosionOptions(string name)
    {
        switch (name)
        {
            case "Bullet_Fire_Med(Clone)":
                exPrefab = Instantiate(explosion, transform.position, Quaternion.identity, null);
                ParticleSystem.MainModule psm = exPrefab.GetComponentInChildren<ParticleSystem>().main;
                Color orange = new Color(255, 140, 0);
                psm.startColor = new ParticleSystem.MinMaxGradient(orange);
                Debug.Log("Orange");
                break;
            case "Bullet_Green_Fire_Low(Clone)":
                exPrefab = Instantiate(explosion, transform.position, Quaternion.identity, null);
                ParticleSystem.MainModule psm1 = exPrefab.GetComponentInChildren<ParticleSystem>().main;
                Color green = new Color(73, 255, 0);
                psm1.startColor = new ParticleSystem.MinMaxGradient(green);
                Debug.Log("Green");
                break;
            case "Bullet_Axe_Med(Clone)":
                exPrefab = Instantiate(axe, transform.position/* + parentTrans.position / 2*/, Quaternion.identity, parentTrans);
                exPrefab.transform.localScale = transform.localScale;
                break;
            case null:
                
                //Instantiate(explosion, transform.position, Quaternion.identity, null);
                break;
            default:
                exPrefab = Instantiate(explosion, transform.position, Quaternion.identity, parentTrans);
                exPrefab.transform.localScale = transform.localScale;
                break;
        }
    }
}
