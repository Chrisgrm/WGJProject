using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target;
    public float height = 10.0f;
    public float distance = 10.0f;

    private void Update()
    {
        Vector3 newPosition = target.position - Vector3.forward * distance + Vector3.up * height;
        transform.position = newPosition;
        transform.LookAt(target.position);
    }
}
