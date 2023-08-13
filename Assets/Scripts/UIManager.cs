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
    public Transform enemy2WordPosition;
    public GameObject doorClosedPanel;


    // Start is called before the first frame update
    void Start()
    {
        dialogePanel.SetActive(false);
        inputField.SetActive(false);
        combatPanel.SetActive(false);

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
        StartCoroutine(ActivateInputCorroutine());
    }

    IEnumerator ActivateInputCorroutine()
    {
        yield return new WaitForSeconds(1);
        inputField.SetActive(true);
        print("Se puede escribir");
        TMP_InputField input = inputField.GetComponentInChildren<TMP_InputField>();
        input.Select();
        input.ActivateInputField();
    }
    public void DeactivateInput()
    {
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

    public string GetInputText()
    {
        TMP_InputField input= inputField.GetComponentInChildren<TMP_InputField>();
        return input.text;
    }
}
