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

    public float mouseSensibility = 2.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isFirstPerson = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (isFirstPerson)
        {
            FirstPersonMovement();

        }
        else
        {
            ThirdPersonMovement();
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            isFirstPerson = !isFirstPerson;
        }
     




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
}
