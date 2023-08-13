using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private UIManager uIManager;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        player = GameObject.Find("PlayerObject").GetComponentInChildren<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(player.Getkeys() >= 3)
        {
            print("se abre la puerta");
        }
        else
        {
            uIManager.ActiveDoorClosed();
        }
    }


}
