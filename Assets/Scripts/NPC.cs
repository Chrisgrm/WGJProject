using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private CameraController cameraController;
    private Player player;

    public int npcId;
    public GameObject playerPosition;

    void Start()
    {
        cameraController = GameObject.Find("CameraController").GetComponent<CameraController>();
        player = GameObject.Find("Player").GetComponentInChildren<Player>();
    }


    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = playerPosition.transform.position;
        player.DisableMovement();
        cameraController.ActivateCameraNPC(npcId);
        
        //player.MovePlayerAutomatic(playerPositionRef);
        
    }
}
