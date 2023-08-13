using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatManager : MonoBehaviour
{
    public TMP_Text enemyAttackText;
    public TMP_InputField playerResponseInput;
    public TMP_Text timerText;
    public TMP_Text correctResponseText;

    [SerializeField]
    private string correctResponse;
    private string[] enemyAttacks = { "Ataque 1", "Ataque 2", "Ataque 3" };

    private int keyFragments = 0;
    [SerializeField]
    private int enemyIndex;

    public Animator panelAnimator; // Animator del panel
    public GameObject combatPanel; // Panel de combate
    public GameObject combatUI; // Cámara de combate
    public GameObject playerPosition; // Posición del jugador

    public Player playerController; // Script de control del jugador
    public CameraController cameraController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Desactivar movimiento del jugador
            playerController.DisableMovement();
            
            combatPanel.SetActive(true); // Activar panel
            panelAnimator.SetTrigger("FadeStart"); // Iniciar animación de entrada

            // Puedes usar una corutina para manejar la secuencia de acciones que siguen
            StartCoroutine(StartCombatSequence());
        }
    }

    public void StartCombat()
    {
        // Elegir ataque enemigo al azar
        int attackIndex = Random.Range(0, enemyAttacks.Length);
        string enemyAttack = enemyAttacks[attackIndex];
        enemyAttackText.text = enemyAttack;

        // Establecer la respuesta correcta en función del ataque elegido
        SetCorrectResponse();

        // Iniciar contador de tiempo
        StartCoroutine(Timer());
    }

    private void SetCorrectResponse()
    {
        correctResponseText.text = correctResponse;
    }

    public void Victory()
    {
        keyFragments++;

        // Entregar fragmento de llave al jugador
        // ...

        if (keyFragments == 3)
        {
            // Victoria total en el juego
            // Puedes cargar una escena de victoria, mostrar un mensaje, etc.
        }
        else
        {
            // Devolver al espacio de juego al jugador
            StartCoroutine(EndCombatSequence());
        }
    }

    public void Defeat()
    {
        // Efectos de derrota
        // ...

        // Devolver al espacio de juego al jugador
        StartCoroutine(EndCombatSequence());
    }

    public void CheckResponse()
    {
        if (playerResponseInput.text == correctResponse)
        {
            Victory();
        }
        else
        {
            Defeat();
        }
    }

    private IEnumerator StartCombatSequence()
    {
        // Esperar a que termine la animación de entrada (ajustar la duración)
        yield return new WaitForSeconds(2.0f);

        // Cambiar a la cámara 2D
        cameraController.SwitchToCombatCamera(enemyIndex);

        // Mover al jugador a la posición 2DenemyIndex
        playerController.transform.position = playerPosition.transform.position;

        // Activar animación de salida
        panelAnimator.SetTrigger("FadeEnd");

        // Esperar a que termine la animación de salida (ajustar la duración)
        yield return new WaitForSeconds(2.0f);

        combatUI.SetActive(true); // Activar UI de combate

        // Iniciar combate
        StartCombat();
    }

    private IEnumerator EndCombatSequence()
    {
        cameraController.SwitchToPreviousCamera();

        playerController.EnableMovement();

        yield return null; // Reemplaza esto con la lógica adecuada
    }

    private IEnumerator Timer()
    {
        float timeRemaining = 10; // Por ejemplo, 10 segundos
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Tiempo restante: " + timeRemaining.ToString("F2");
            yield return null;
        }

        // Tiempo agotado
    }
}
