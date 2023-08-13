using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private CameraController cameraController;
    private Player player;
    public PlayerAnimationController animationController;


    public int npcId;
    public GameObject playerPosition;

    public Transform playerPositionRef;
    public string[] dialogueSentences;
    private int currentSentenceIndex;
    private UIManager uIManager;
    private bool isConversationActive;
    bool canTalk;


    void Start()
    {
        cameraController = GameObject.Find("CameraController").GetComponent<CameraController>();
        player = GameObject.Find("PlayerObject").GetComponentInChildren<Player>();
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        animationController = player.GetComponent<PlayerAnimationController>();
        canTalk = true;
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

    private void ActivateInputField()
    {
        uIManager.ActivateInputField();       
    }


    private void OnTriggerEnter(Collider other)
    {

        if (canTalk)
        {
            player.transform.position = playerPosition.transform.position;
            player.DisableMovement();
            cameraController.ActivateCameraNPC(npcId); 
            StartConversation();
        }
       

        
        //player.MovePlayerAutomatic(playerPositionRef);

        //player.BlockMovement();
        //player.MovePlayerAutomatic(playerPositionRef);
     

        
    }

    private void StopConversation()
    {
        canTalk = false;
        uIManager.EndDialog();
        currentSentenceIndex = 0;
        //cameraController.Switch2ThirdPerson();
        isConversationActive = false;
        StartTopDownView();
        
    }

    private void LiberatePlayer()
    {
        uIManager.DeactivateInput();
        player.SetThirdPerson();
        cameraController.Switch2ThirdPerson();
        player.EnableMovement();
        animationController.SetInteract();
        StartCoroutine(CanTalk());
        uIManager.DeactiveThanksAdvice();
    }

    IEnumerator CanTalk()
    {
        yield return new WaitForSeconds(3);
        canTalk = true;
    }
    private void StartTopDownView()
    {
        ActivateInputField();
        cameraController.SetTopDownCamera(npcId);
        cameraController.Switch2TopDown();
        uIManager.ActiveThanksAdvice();
        StartCoroutine(CheckWord("gracias"));

    }

    IEnumerator CheckWord(string word)
    {

        
        while(uIManager.GetInputText()!= word)
        {

            yield return null; 
        }

        LiberatePlayer();
    }

    private void StartConversation()
    {
        isConversationActive = true;
        uIManager.ActivateDialog(dialogueSentences[currentSentenceIndex]);
        //dialogueText.gameObject.SetActive(true);
        //continuePrompt.SetActive(true);
    }
}
