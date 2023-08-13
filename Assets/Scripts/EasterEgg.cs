using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    private UIManager uIManager; 
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        uIManager.ActivatePanelEasterEgg();
    }
    private void OnTriggerExit(Collider other)
    {
        uIManager.DeactivatePanelEasterEgg();
    }
}
