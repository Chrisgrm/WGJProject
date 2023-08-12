using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float velocity;

    public float mouseSensibility = 2.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 movimiento = new Vector3(horizontalInput, 0.0f, verticalInput);


        Vector3 movimientoGlobal = transform.TransformDirection(movimiento);

        rb.AddForce(movimientoGlobal * velocity);

        float mouseMovementX = Input.GetAxis("Mouse X");
        Vector3 rotacion = new Vector3(0.0f, mouseMovementX * mouseSensibility, 0.0f);

        // Aplicar la rotación localmente al transform del cubo
        transform.Rotate(rotacion);




    }
}
