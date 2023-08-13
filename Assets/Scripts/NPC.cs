using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private CameraController cameraController;
    public int npcId;
    private Player player;
    public Transform playerPositionRef;
    void Start()
    {
        cameraController = GameObject.Find("CameraController").GetComponent<CameraController>();
        player = GameObject.Find("Player").GetComponentInChildren<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        cameraController.ActivateCameraNPC(npcId);
        player.BlockMovement();
        player.MovePlayerAutomatic(playerPositionRef);
        
    }
}
