using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        if (horizontalInput > 0)
        {
            rb.MovePosition(Vector3.right * horizontalInput * velocity * Time.deltaTime);
        }
        if (verticalInput > 0)
        {
            rb.MovePosition(Vector3.forward * verticalInput * velocity * Time.deltaTime);
        }

        

        
    }
}
