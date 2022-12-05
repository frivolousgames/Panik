using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AssignPlayerVCam : MonoBehaviour
{

    CinemachineVirtualCamera vc;

    private void Awake()
    {
        vc = GetComponent<CinemachineVirtualCamera>();
        
    }

    private void Start()
    {
        vc.Follow = GameObject.FindGameObjectWithTag("Player").transform;
        vc.LookAt = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
