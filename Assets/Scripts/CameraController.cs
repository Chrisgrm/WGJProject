using UnityEngine;
using Cinemachine;
using System;

public class CameraController : MonoBehaviour
{
    //esto sirve pa monda!
    public CinemachineVirtualCamera firstPersonCamera;
    public CinemachineVirtualCamera thirdPersonCamera;
    public CinemachineVirtualCamera topDownCamera;
    public CinemachineVirtualCamera combatCamera,
        combatCamera1,
        combatCamera2;

    public GameObject cameraThirdPerson, cameraFirstPerson, cameraTopDown, cameraNPC1, cameraNPC2, cameraNPC3;

    private int activeCameraIndex = 0;
    private CinemachineVirtualCamera previousCamera;

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

    public void SwitchToCombatCamera(int cameraIndex)
    {
        previousCamera = firstPersonCamera.gameObject.activeSelf
            ? firstPersonCamera
            : thirdPersonCamera;


        cameraThirdPerson.gameObject.SetActive(false);
        cameraFirstPerson.gameObject.SetActive(false);
        
        switch (cameraIndex)
        {
            case 0:
                combatCamera.gameObject.SetActive(true);
                break;
            case 1:
                combatCamera1.gameObject.SetActive(true);
                break;
            case 2:
                combatCamera2.gameObject.SetActive(true);
                break;
            
            default:
                Debug.Log("Opción no válida");
                break;
        }
    }

    public void SwitchToPreviousCamera()
    {
        combatCamera.gameObject.SetActive(false);
        previousCamera.gameObject.SetActive(true);
    }
}
