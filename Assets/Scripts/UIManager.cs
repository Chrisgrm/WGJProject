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
    
    // Start is called before the first frame update
    void Start()
    {
        dialogePanel.SetActive(false);
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
}
