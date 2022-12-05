using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject leftBarrier;
    public GameObject rightBarrier;

    private void Start()
    {
        OpenDoors();
    }

    void OpenDoors()
    {
        if(leftDoor != null)
        {
            leftDoor.SetActive(true);
            leftBarrier.SetActive(false);
        }

        if (rightDoor != null)
        {
            rightDoor.SetActive(true);
            rightBarrier.SetActive(false);
        }
    }

    void CloseDoors()
    {
        if (leftDoor != null)
        {
            leftDoor.SetActive(false);
            leftBarrier.SetActive(true);
        }

        if (rightDoor != null)
        {
            rightDoor.SetActive(false);
            rightBarrier.SetActive(true);
        }
    }
}
