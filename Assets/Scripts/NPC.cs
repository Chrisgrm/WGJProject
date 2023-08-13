using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private CameraController cameraController;
    public int npcId;
    private Player player;
    public Transform playerPositionRef;
    public string[] dialogueSentences;
    private int currentSentenceIndex;
    private UIManager uIManager;
    private bool isConversationActive;

    void Start()
    {
        cameraController = GameObject.Find("CameraController").GetComponent<CameraController>();
        player = GameObject.Find("Player").GetComponentInChildren<Player>();
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
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
                    uIManager.EndDialog();
                    cameraController.Switch2ThirdPerson();
                    player.SetThirdPerson();
                    isConversationActive = false;
                    player.BlockMovement();
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
        cameraController.ActivateCameraNPC(npcId);
        player.BlockMovement();
        player.MovePlayerAutomatic(playerPositionRef);
        StartConversation();
        
    }

    private void StartConversation()
    {
        isConversationActive = true;
        uIManager.ActivateDialog(dialogueSentences[currentSentenceIndex]);
        //dialogueText.gameObject.SetActive(true);
        //continuePrompt.SetActive(true);
    }
}
