using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;

    RigidbodyFirstPersonController fpsController;
    [SerializeField] float sensZoomedOut = 2f;
    [SerializeField] float sensZoomedIn = 1f;

    bool zoomedInToggle = false;

    void Start()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    void Update()
    {
        HandleZoom();
    }

    void HandleZoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
               ZoomIn();
            }
            else
            {
               ZoomOut();
            }
        }
    }
    void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
        fpsController.mouseLook.XSensitivity = sensZoomedIn;
        fpsController.mouseLook.YSensitivity = sensZoomedIn;
    }
    void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        fpsController.mouseLook.XSensitivity = sensZoomedOut;
        fpsController.mouseLook.YSensitivity = sensZoomedOut;
    }
}
