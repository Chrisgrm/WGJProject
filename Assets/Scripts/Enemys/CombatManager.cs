using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatManager : MonoBehaviour
{

    private string[] playerAttacks = {"confianza","autoestima","paz" };
    private List<string> playerAttacksUnused;
   // public TMP_Text timerText;
    public TMP_Text correctResponseText;

    [SerializeField]
    private string correctResponse;
    private string[] enemyAttacks = { "Te has visto en un espejo? todos pueden verlo, no encajas en este mundo.", "Nunca puedes hacer nada bien. Solo estás perdiendo el tiempo aquí", "Esa sonrisa tuya, ¿crees que la gente no ve lo falsa que es?" };

    private int keyFragments = 0;

    [SerializeField]
    private int enemyIndex;
    private int correctResponses = 0;

    public Animator panelAnimator; // Animator del panel 
 
    public GameObject playerPosition; // Posición del jugador
    public GameObject playerPosition2; // Posición del jugador

    public Player playerController; // Script de control del jugador
    public CameraController cameraController;
    public PlayerAnimationController animationController;
    private UIManager uIManager;
    private bool playerCanAttack;
    private int plantLife;
    private bool canFight;
    private bool playerWin;

    private void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        animationController = GameObject.Find("PlayerObject").GetComponent<PlayerAnimationController>();
        canFight = true;
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
            if (canFight)
            {
                playerController.DisableMovement();
                animationController.SetIdle();
                //uIManager.
                panelAnimator.SetTrigger("FadeStart"); // Iniciar animación de entrada

                // Puedes usar una corutina para manejar la secuencia de acciones que siguen
                StartCoroutine(StartCombatSequence());
            }
        }
            // Desactivar movimiento del jugador
           
    }

    public void StartCombat()
    {
        playerWin = false;

        animationController.SetTalk();
        
        // Elegir ataque enemigo al azar
        int attackIndex = Random.Range(0, enemyAttacks.Length);
        string enemyAttack = enemyAttacks[attackIndex];
        // enemyAttackText.text = enemyAttack;
        uIManager.ChangeEnemyText(enemyAttack);
        uIManager.ActivateInputField();
        // Establecer la respuesta correcta en función del ataque elegido
        
        StartCoroutine(Timer(false));
        StartCoroutine(CheckWord(playerAttacks));

        // Iniciar contador de tiempo
    

    }

    IEnumerator CheckWord(string[] words)
    {

        if (playerCanAttack)
        {
            while (uIManager.GetInputText() != words[0] || uIManager.GetInputText() != words[1] || uIManager.GetInputText() != words[2])
            {
                if(uIManager.GetInputText() == words[0] || uIManager.GetInputText() == words[1] || uIManager.GetInputText() == words[2])
                {

                    words[0] = "unapalabraquejamasvayanaescribir2";
                    
                    uIManager.RestarInput();
                    print("hice daño");
                    PlantGetDamage();
                    
                }else if (uIManager.GetInputText() == words[1])
                {
                    words[1] = "unapalabraquejamasvayanaescribir2";
                   
                    uIManager.RestarInput();
                    print("hice daño");
                    PlantGetDamage();
                }
                else if (uIManager.GetInputText() == words[2])
                {
                    words[2] = "unapalabraquejamasvayanaescribir2";
                    uIManager.RestarInput();
                    print("hice daño");
                    PlantGetDamage();
                }
               
                if (!playerCanAttack)
                {
                    break;
                }
                yield return null;
            }

        }
        if (!playerWin)
        {
            print("pase por defeat");
            Defeat();

        }

   // LiberatePlayer();
    }

 

    private void PlantGetDamage()
    {
        if (plantLife<=0)
        {
            Victory();
        }
        
    }

    private void SetCorrectResponse()
    {
        correctResponseText.text = correctResponse;
    }

    public void Victory()
    {
        playerWin = true;
        correctResponses++;
        int requiredResponses = enemyIndex + 1;

        if (correctResponses == requiredResponses)
        {
            playerController.GetKey();
            correctResponses = 0; // Reiniciar contador 
                                  // Devolver al espacio de juego al jugador
            
            KillPlant();
        }
         else
         {
            print("se inicia segundo round");
            StopAllCoroutines();
             StartCombat(); // Iniciar el siguiente turno si aún no ha alcanzado las respuestas requeridas
         }
    }

    private void KillPlant()
    {

        print("panta muerta");
        Timer(true);
        canFight = false;
        uIManager.DeactivateBattle();
        EndCombatSequence(false);
    }

    public void Defeat()
    {
        correctResponses = 0; // Reiniciar contador
        StartCoroutine(InactiveController());
        animationController.SetDefeat();
        animationController.SetDefeat();
        // Efectos de derrota
        playerController.transform.localScale *= 0.9f; // Hacer al jugador más pequeño
        uIManager.DeactivateBattle();
        // Devolver al espacio de juego al jugador
        // Mover al jugador a la posición 2DenemyIndex
        playerController.transform.position = playerPosition2.transform.position;

        EndCombatSequence(true);
    }

    public void CheckResponse()
    {
        //if (playerResponseInput.text == correctResponse)
        //{
        //    Victory();
        //}
        //else
        //{
        //    Defeat();
        //}
    }

    private IEnumerator StartCombatSequence()
    {
        // Esperar a que termine la animación de entrada (ajustar la duración)
        //yield return new WaitForSeconds(2.0f);

        // Cambiar a la cámara 2D
        cameraController.SwitchToCombatCamera(enemyIndex);

        // Mover al jugador a la posición 2DenemyIndex
        playerController.transform.position = playerPosition.transform.position;

        // Activar animación de salida
        panelAnimator.SetTrigger("FadeEnd");
        RestarPlayerWords();

        // Esperar a que termine la animación de salida (ajustar la duración)
        uIManager.ActivateBattle();
        yield return new WaitForSeconds(4.0f);

       // combatUI.SetActive(true); // Activar UI de combate

        // Iniciar combate
        StartCombat();
    }

    private void RestarPlayerWords()
    {
        playerAttacks[0] = "confianza"; 
        playerAttacks[1] = "autoestima"; 
        playerAttacks[2] = "paz"; 
    }

    private void EndCombatSequence(bool isDefeat)
    {
        if (!isDefeat && playerController.transform.localScale.x < 1)
        {
            playerController.transform.localScale = Vector3.one; // Restaurar la escala del jugador
        }

        animationController.SetIdle();
        playerController.EnableMovement();

        if (isDefeat)
        {
            print("primera PErsona");
            cameraController.Switch2FirstPerson();
            playerController.SetFirstPerson();
        }     
        else
        {
            
            playerController.SetThirdPerson();
            print("tercerapersona");
            cameraController.Switch2ThirdPerson(); // Activar cámara de tercera persona
        }
        
        /*yield return null;*/ // Reemplaza esto con la lógica adecuada
    }

    private IEnumerator Timer(bool stop)
    {
        playerCanAttack = true;
        float timeRemaining = 5; // Por ejemplo, 10 segundos
        if (stop) { timeRemaining = 0; }
        while (timeRemaining > 0.1)
        {
           
        //print(timeRemaining);
            timeRemaining -= Time.deltaTime;
           // timerText.text = "Tiempo restante: " + timeRemaining.ToString("F2");
            yield return null;
        }        
        playerCanAttack = false;
        // Tiempo agotado
    }

    private IEnumerator InactiveController()
    {
        yield return new WaitForSeconds(4);
        canFight = true;

    }
}
