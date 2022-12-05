using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSmokeTrail : MonoBehaviour
{
    ParticleSystem.MainModule ps;
    ParticleSystem.EmissionModule psys;
    ParticleSystem pss;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>().main;
        psys = GetComponent<ParticleSystem>().emission;
        pss = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if(transform.parent == null)
        {
            ps.startLifetime = 0f;
            ps.loop = false;
        }
       
            //pss.Pause();
            //psys.rateOverTime = 0;
            //ps.loop = false;
    }
}
