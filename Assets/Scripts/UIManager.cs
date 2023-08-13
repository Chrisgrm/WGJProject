using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public GameObject dialogePanel;
    public GameObject inputField;
    public GameObject enemyAttackText;
    public GameObject combatPanel;
    public Transform enemy0WordPosition;
    public Transform enemy1WordPosition;
    public GameObject easterEggPanel;
    public GameObject inGamePanel;


    public Transform enemy2WordPosition;
    public GameObject doorClosedPanel;
    private bool inputActive;
    public GameObject pausePanel;
    public GameObject thanksPanel;
    public Image key1Image;
    public Image key2Image;
    public Image key3Image;


    // Start is called before the first frame update
    void Start()
    {
        dialogePanel.SetActive(false);
        inputField.SetActive(false);
        combatPanel.SetActive(false);
        doorClosedPanel.SetActive(false);
        easterEggPanel.SetActive(false);
        thanksPanel.SetActive(false);
        key1Image.gameObject.SetActive(false);
        key2Image.gameObject.SetActive(false);
        key3Image.gameObject.SetActive(false);
    }
    internal void ActivatePanelEasterEgg()
    {
        easterEggPanel.SetActive(true);
    }

    internal void DeactivatePanelEasterEgg()
    {
        easterEggPanel.SetActive(false);
    }

    internal void ActiveDoorClosed()
    {
        doorClosedPanel.SetActive(true);
    }

    internal void DeactiveDoorClosed()
    {
        doorClosedPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateBattle()
    {
        enemyAttackText.GetComponent<TMP_Text>().text = "";
        enemyAttackText.transform.position = enemy0WordPosition.position;
        combatPanel.SetActive(true);
    } 

    public void ChangeEnemyText(string text)
    {
        enemyAttackText.GetComponent<TMP_Text>().text = text;
    }
    
    public void DeactivateBattle()
    {
        combatPanel.SetActive(false);
        DeactivateInput();
    }

    internal void ActivePause()
    {
        pausePanel.SetActive(true);
    }
    internal void DeactivePause()
    {
        pausePanel.SetActive(false);
    }

    public void ActivateDialog(string textoInicial)
    {
        dialogePanel.SetActive(true);
        dialogueText.text = textoInicial;
    }

    public void ChangeDialog(string texto)
    {
        dialogueText.text = texto;
    }

    internal void EndDialog()
    {
        dialogePanel.SetActive(false);

    }

    internal void ActivateInputField()
    {
        if (!inputActive)
        {
        StartCoroutine(ActivateInputCorroutine());

        }
    }

    IEnumerator ActivateInputCorroutine()
    {
        inputActive = true;
        yield return new WaitForSeconds(1);
        inputField.SetActive(true);
        print("Se puede escribir");
        TMP_InputField input = inputField.GetComponentInChildren<TMP_InputField>();
        input.Select();
        input.ActivateInputField();
    }
    public void DeactivateInput()
    {
        inputActive = false;
        print("final");
        inputField.SetActive(false);
        TMP_InputField input = inputField.GetComponentInChildren<TMP_InputField>();     
        input.text = "";

    }

    public void RestarInput()
    {
        TMP_InputField input = inputField.GetComponentInChildren<TMP_InputField>();
        input.text = "";
    }

    internal void DeactiveThanksAdvice()
    {
        thanksPanel.SetActive(false);
    }

    internal void ActiveThanksAdvice()
    {
        thanksPanel.SetActive(true);
    }

    public string GetInputText()
    {
        TMP_InputField input= inputField.GetComponentInChildren<TMP_InputField>();
        return input.text;
    }

    internal void ActiveInGameKey()
    {
        inGamePanel.SetActive(true);
    }

    public void ActiveKeyImage(int cantidad) {
        if (cantidad == 1)
        {
            key1Image.gameObject.SetActive(true);
        }        if (cantidad == 2)
        {
            key2Image.gameObject.SetActive(true);
        }        if (cantidad == 3)
        {
            key3Image.gameObject.SetActive(true);
        }
    }
}
