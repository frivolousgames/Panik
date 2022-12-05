using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCam : MonoBehaviour
{
    CinemachineVirtualCamera cam;

    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        cam.m_Lens.Dutch = Mathf.Lerp(Random.Range(-1.5f, 1.5f), Random.Range(1, 2), Time.deltaTime);
    }
}
