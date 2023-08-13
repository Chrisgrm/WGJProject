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

 

    // Start is called before the first frame update
    void Start()
    {
        dialogePanel.SetActive(false);
        inputField.SetActive(false);
        
}

    // Update is called once per frame
    void Update()
    {
        
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
        yield return new WaitForSeconds(2);
        inputField.SetActive(true);
        print("holaa");
        TMP_InputField input = inputField.GetComponentInChildren<TMP_InputField>();
        input.Select();
        input.ActivateInputField();
    }
    public void DeactivateInput()
    {
        inputField.SetActive(false);
        TMP_InputField input = inputField.GetComponentInChildren<TMP_InputField>();     
        input.text = "";

    }

    public string GetInputText()
    {
        TMP_InputField input= inputField.GetComponentInChildren<TMP_InputField>();
        return input.text;
    }
}
