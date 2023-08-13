using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private CameraController cameraController;
    private Player player;


    public int npcId;
    public GameObject playerPosition;

    public Transform playerPositionRef;
    public string[] dialogueSentences;
    private int currentSentenceIndex;
    private UIManager uIManager;
    private bool isConversationActive;


    void Start()
    {
        cameraController = GameObject.Find("CameraController").GetComponent<CameraController>();
        player = GameObject.Find("PlayerObject").GetComponentInChildren<Player>();
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }


 
    void Update()
    {
        if (isConversationActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentSentenceIndex < dialogueSentences.Length - 1)
                {
                    currentSentenceIndex++;
                    uIManager.ChangeDialog(dialogueSentences[currentSentenceIndex]);
                }
                else
                {
                    StopConversation();
                }
            }

            //if (Input.GetKeyDown(KeyCode.Return))
            //{
            //    if (currentSentenceIndex == dialogueSentences.Length - 1)
            //    {
            //        if (InputFieldMatchesActionKeyword())
            //        {
            //            PerformAction();
            //        }
            //    }
            //}
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = playerPosition.transform.position;
        player.DisableMovement();
        cameraController.ActivateCameraNPC(npcId);

        
        //player.MovePlayerAutomatic(playerPositionRef);

        //player.BlockMovement();
        //player.MovePlayerAutomatic(playerPositionRef);
        StartConversation();

        
    }

    private void StopConversation()
    {
        uIManager.EndDialog();
        currentSentenceIndex = 0;
        cameraController.Switch2ThirdPerson();
        StartView();
        player.SetThirdPerson();
        isConversationActive = false;
        player.EnableMovement();
    }

    private void StartView()
    {
        cameraController.SetTopDownCamera(npcId);
        cameraController.Switch2TopDown();

    }

    private void StartConversation()
    {
        isConversationActive = true;
        uIManager.ActivateDialog(dialogueSentences[currentSentenceIndex]);
        //dialogueText.gameObject.SetActive(true);
        //continuePrompt.SetActive(true);
    }
}
