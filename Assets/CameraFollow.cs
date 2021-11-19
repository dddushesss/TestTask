using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smothSpeed = 0.1f;
    [SerializeField] private Vector3 offset;

    private void FixedUpdate()
    {
        if(target == null)
            return;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smothedPosition = Vector3.Lerp(transform.position, desiredPosition, smothSpeed * Time.deltaTime);
        transform.position = smothedPosition;
    }
}
