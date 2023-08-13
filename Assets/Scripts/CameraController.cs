using UnityEngine;
using Cinemachine;
using System;

public class CameraController: MonoBehaviour
{
    public CinemachineVirtualCamera firstPersonCamera;
    public CinemachineVirtualCamera thirdPersonCamera;
    public CinemachineVirtualCamera topDownCamera;

    public GameObject cameraThirdPerson, cameraFirstPerson, cameraTopDown, cameraNPC1, cameraNPC2, cameraNPC3;

    private int activeCameraIndex = 0;

    private void Start()
    {

        SwitchCamera(activeCameraIndex);
        cameraNPC1.SetActive(false);
        cameraNPC2.SetActive(false);
        cameraNPC3.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            activeCameraIndex = (activeCameraIndex + 1) % 3;
            SwitchCamera(activeCameraIndex);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            
            SwitchThird2Person();
        }
    }

    public void ActivateCameraNPC(int v)
    {
        cameraFirstPerson.SetActive(false);
        cameraThirdPerson.SetActive(false);
        switch (v)
        {
            case 1:
                cameraNPC1.SetActive(true);
                print("camara 1");

                break;

            case 2:
                cameraNPC2.SetActive(true);
                break;
            case 3:
                cameraNPC3.SetActive(true);
                break;

        }
    }

    private void SwitchCamera(int index)
    {
        firstPersonCamera.gameObject.SetActive(index == 0);
        thirdPersonCamera.gameObject.SetActive(index == 1);
        topDownCamera.gameObject.SetActive(index == 2);
    } 
    
    private void SwitchThird2Person()
    {
        cameraFirstPerson.SetActive(false);
        cameraThirdPerson.SetActive(true);
    }
}