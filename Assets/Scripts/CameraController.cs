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

    public GameObject cameraThirdPerson, cameraFirstPerson, cameraTopDown, cameraNPC0, cameraNPC1, cameraNPC2;

    private int activeCameraIndex = 0;
    private CinemachineVirtualCamera previousCamera;

    private void Start()
    {

        SwitchCamera(activeCameraIndex);
        cameraNPC0.SetActive(false);


        //SwitchCamera(activeCameraIndex);
        cameraFirstPerson.SetActive(false);
        cameraThirdPerson.SetActive(true);
        cameraTopDown.SetActive(false);

        cameraNPC1.SetActive(false);
        cameraNPC2.SetActive(false);
    }

    private void Update()
    {
   

        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    activeCameraIndex = (activeCameraIndex + 1) % 3;
        //    SwitchCamera(activeCameraIndex);
        //}
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    Switch2ThirdPerson;


        //}

    }

    public void ActivateCameraNPC(int v)
    {
        cameraFirstPerson.SetActive(false);
        cameraThirdPerson.SetActive(false);
        switch (v)
        {
            case 1:
                cameraNPC0.SetActive(true);
                break;

            case 2:
                cameraNPC1.SetActive(true);
                break;
            case 3:
                cameraNPC0.SetActive(true);
                break;

        }
    }

    private void SwitchCamera(int index)
    {
        firstPersonCamera.gameObject.SetActive(index == 0);
        thirdPersonCamera.gameObject.SetActive(index == 1);
        topDownCamera.gameObject.SetActive(index == 2);
    }

    public void Switch2FirstPerson()
    {
        cameraFirstPerson.SetActive(true);
        cameraThirdPerson.SetActive(false);
        cameraTopDown.SetActive(true);
    } 
    public void Switch2ThirdPerson()

    {
        cameraFirstPerson.SetActive(false);
        cameraThirdPerson.SetActive(true);
        cameraTopDown.SetActive(false);
    } 
    public void Switch2TopDown()
    {
        cameraFirstPerson.SetActive(false);
        cameraThirdPerson.SetActive(false);
        cameraTopDown.SetActive(true);
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
