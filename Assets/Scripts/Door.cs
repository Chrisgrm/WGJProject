using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private UIManager uIManager;
    private Player player;
    public PlayerAnimationController animationController;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        player = GameObject.Find("PlayerObject").GetComponentInChildren<Player>();
        animationController = player.GetComponent<PlayerAnimationController>();
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
            player.DisableMovement();
            animationController.SetVictory();
        }
        else
        {
            uIManager.ActiveDoorClosed();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        uIManager.DeactiveDoorClosed();
    }

}
