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

    public Animator panelAnimator; // Animator del panel
    public Camera secondCamera; // Cámara para la perspectiva 2D
    public GameObject combatPanel; // Panel de combate
    public GameObject playerPosition; // Posición del jugador en 2D
    public GameObject backGround2D; // Fondo 2D
    public Player playerController; // Script de control del jugador

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
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
        yield return new WaitForSeconds(1.0f); 

        backGround2D.SetActive(true); // Activar fondo 2D

        // Cambiar a la cámara 2D
        secondCamera.enabled = true;

        // Mover al jugador a la posición 2D
        playerController.transform.position = playerPosition.transform.position;

        // Desactivar movimiento del jugador
        //playerController.DisableMovement();

        // Activar animación de salida
        panelAnimator.SetTrigger("FadeEnd");

        // Esperar a que termine la animación de salida (ajustar la duración)
        yield return new WaitForSeconds(1.0f); 

        // Iniciar combate
        StartCombat();
    }

    private IEnumerator EndCombatSequence()
    {
        // Realizar un proceso inverso al de StartCombatSequence
        // Cambiar de la perspectiva 2D a 3D, etc.
        // ...
        
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
