using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    public Camera topDownCamera;

    private int activeCameraIndex = 0;

    private void Start()
    {
        SwitchCamera(activeCameraIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            activeCameraIndex = (activeCameraIndex + 1) % 3;
            SwitchCamera(activeCameraIndex);
        }
    }

    private void SwitchCamera(int index)
    {
        firstPersonCamera.gameObject.SetActive(index == 0);
        thirdPersonCamera.gameObject.SetActive(index == 1);
        topDownCamera.gameObject.SetActive(index == 2);
    }
}
