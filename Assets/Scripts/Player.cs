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
    float horizontalInput ;
    float verticalInput;
    [SerializeField]
    float rotationSpeed = 20;
    bool isFirstPerson;
    bool blokedMovement;
    bool isMoving;
    Transform targetPosition;

    public float mouseSensibility = 2.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isFirstPerson = true;
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


        if (isMoving)
        {
            Vector3 targetDirection = targetPosition.position - transform.position;
            Vector3 movement = targetDirection.normalized * speed * Time.deltaTime;

            // Mueve al personaje hacia la posición deseada
            transform.Translate(movement);

            // Comprueba si el personaje ha llegado a la posición deseada
            if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
            {
                isMoving = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            isFirstPerson = !isFirstPerson;
        }
     




    }

    public void BlockMovement()
    {
        blokedMovement = true;
    }

    private void ThirdPersonMovement()
    {
        GetInput();
        Vector3 movement = new Vector3(0, 0.0f, verticalInput);
        Vector3 globalMovement = transform.TransformDirection(movement);
        rb.AddForce(globalMovement * speed);
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;

        print(rotation);
        transform.Rotate(Vector3.up, rotation);
    }

    public void MovePlayerAutomatic(Transform target)
    {
        StartCoroutine(MovePlayerAutomaticCorroutine(target));
        print("puta");
    }
    IEnumerator MovePlayerAutomaticCorroutine(Transform target)
    {
        isMoving = true;
        Vector3 initialPosition = transform.position;
        Vector3 targetDirection = (target.position - initialPosition);

        print(target.position);
        
        while (Vector3.Distance(transform.position, target.position) > 0.5f)
        {
            Vector3 movement = targetDirection.normalized* speed * Time.deltaTime;
            print("movimiento: "+ movement);

            // Mueve al personaje hacia la posición deseada

            transform.Translate(movement);
            //rb.MovePosition(movement);

            yield return null;
        }

        isMoving = false;


    }
    private void FirstPersonMovement()
    {
        GetInput();      
        Vector3 movimiento = new Vector3(horizontalInput, 0.0f, verticalInput);
        Vector3 movimientoGlobal = transform.TransformDirection(movimiento);   
        rb.AddForce(movimientoGlobal * speed);
        transform.rotation = Quaternion.Euler(0, targetCam.rotation.eulerAngles.y, 0);
    }

    private void GetInput()
    {
        horizontalInput =  Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    isMoving = true;
    //    targetPosition = other.transform;
    //}
}
