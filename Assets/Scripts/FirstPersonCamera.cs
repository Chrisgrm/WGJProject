using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public Vector3 rotationOffset;

    private void Update()
    {
        Vector3 targetPosition = player.position + player.TransformDirection(offset);
        transform.position = targetPosition;

        Vector3 targetRotation = player.eulerAngles + rotationOffset;
        transform.eulerAngles = targetRotation;
    }
}
