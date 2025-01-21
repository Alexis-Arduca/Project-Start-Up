using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOnMap : MonoBehaviour
{
    public GameObject map;
    public GameObject newCamera;
    
    private Transform mapTransform;
    private Transform cameraTransform;
    
    private Vector3 mapPosition;
    private Vector3 originalCameraPosition;
    private Quaternion originalCameraRotation;
    private Vector3 cameraPosition;

    private float cameraSpeed;
    
    private bool zoomed = false;
    
    private void Start()
    {
        mapTransform = map.GetComponent<Transform>();
        cameraTransform = newCamera.GetComponent<Transform>();
        
        mapPosition = mapTransform.position;
        cameraPosition = cameraTransform.position;
        originalCameraPosition = cameraPosition;
        originalCameraRotation = cameraTransform.rotation;
        
        cameraSpeed = 0.1f;
    }
    
    private void Update()
    {
        if (zoomed)
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, cameraPosition, cameraSpeed);
            cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, Quaternion.Euler(90, 0, 0), cameraSpeed);
        }
        else
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, originalCameraPosition, cameraSpeed);
            cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, originalCameraRotation, cameraSpeed);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            zoomed = true;
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        zoomed = false;
    }
}
