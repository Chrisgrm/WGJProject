using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed;
    public Transform targetCam;
    float horizontalInput;
    float verticalInput;

    [SerializeField]
    float rotationSpeed = 20;
    bool isFirstPerson;

    bool canMove = true;

    private bool canChangeSize;
    bool blokedMovement;
    bool isMoving;
    Transform targetPosition;
    int keyFragments;


    public float mouseSensibility = 2.0f;
    public PlayerAnimationController animationController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animationController = GetComponent<PlayerAnimationController>();

        isFirstPerson = false;
        isMoving = false;

    }

    // Update is called once per frame
    void Update()
    {


        if (!blokedMovement)
        {
            if (isFirstPerson)
            {
                FirstPersonMovement();
            }
            else
            {
                ThirdPersonMovement();
            }

        }
        else
        {
            ThirdPersonMovement();
        }

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    isFirstPerson = !isFirstPerson;
        //}

        if (Input.GetKeyDown(KeyCode.Alpha9)) // Detectar la pulsación de la tecla 'M'
        {
            animationController.SetEasterEgg(); // Llamar al método SetEasterEgg
        }

    }

    public void SetThirdPerson()
    {
        isFirstPerson = false;
        canChangeSize = true;
    } 
    
    public void SetFirstPerson()
    {
        isFirstPerson = true;
       //canChangeSize = true;
    }

    //public void BlockMovement()
    //{
    //    blokedMovement = true;
    //}

    private void ThirdPersonMovement()
    {
        if (!canMove) return;

        GetInput();
        Vector3 movement = new Vector3(0, 0.0f, verticalInput);
        Vector3 globalMovement = transform.TransformDirection(movement);
        rb.AddForce(globalMovement * speed);
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;

        if (verticalInput != 0 || horizontalInput != 0) // Si hay movimiento
        {
            animationController.SetWalk(); // Configurar la animación de caminar
        }
        else
        {
            animationController.SetIdle(); // Configurar la animación de Idle
        }

        transform.Rotate(Vector3.up, rotation);
    }

    private void FirstPersonMovement()
    {
        if (!canMove) return;

          
        GetInput();
        Vector3 movimiento = new Vector3(horizontalInput, 0.0f, verticalInput);
        Vector3 movimientoGlobal = transform.TransformDirection(movimiento);
        rb.AddForce(movimientoGlobal * speed);
        transform.rotation = Quaternion.Euler(0, targetCam.rotation.eulerAngles.y, 0);

        if (verticalInput != 0 || horizontalInput != 0) // Si hay movimiento
        {
            animationController.SetWalk(); // Configurar la animación de caminar
        }
        else
        {
            animationController.SetIdle(); // Configurar la animación de Idle
        }
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    internal void GetKey()
    {
        keyFragments++;
    }
    public int Getkeys()
    {
        return keyFragments;
    }
}
