using UnityEngine;
using Cinemachine;

public class CameraController: MonoBehaviour
{
    public CinemachineVirtualCamera firstPersonCamera;
    public CinemachineVirtualCamera thirdPersonCamera;
    public CinemachineVirtualCamera topDownCamera;

    public GameObject cameraThirdPerson, cameraFirstPerson, cameraTopDown;

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
        if (Input.GetKeyDown(KeyCode.V))
        {
            
            SwitchThird2Person();
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