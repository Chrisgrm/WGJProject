using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private UIManager uIManager;
    private Player player;
    private PlayerAnimationController animationController;
    private CameraController cameraController;

    public GameObject teleportPosition;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        player = GameObject.Find("PlayerObject").GetComponentInChildren<Player>();
        animationController = player.GetComponent<PlayerAnimationController>();
        cameraController = GameObject.Find("CameraController").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update() { }

    private IEnumerator VictorySequence()
    {
        // Teletransportar al jugador a la posición deseada
        player.transform.position = teleportPosition.transform.position;
        cameraController.SwitchToDoorCamera();
        // Esperar un breve momento antes de comenzar la animación de victoria
        yield return new WaitForSeconds(3f);

        // Activar la animación de victoria
        animationController.SetVictory();

        // Esperar mientras la animación de victoria se reproduce
        yield return new WaitForSeconds(2.0f); // Ajustar la duración según la animación

        // Iniciar la animación de desvanecimiento (fade out)
        //uIManager.FadeOut();

        // Esperar mientras el desvanecimiento ocurre
        yield return new WaitForSeconds(1.0f); // Ajustar la duración según la animación
        SceneManager.LoadScene(2);


        // Aquí puedes colocar cualquier acción adicional, como cargar una nueva escena

        // Iniciar la animación de aparición (fade in)
        //uIManager.FadeIn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.Getkeys() >= 3)
        {
            print("se abre la puerta");
            player.DisableMovement();

            // Llamar a la corutina de la secuencia de victoria
            StartCoroutine(VictorySequence());
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
