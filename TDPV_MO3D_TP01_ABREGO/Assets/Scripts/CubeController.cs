using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeController : MonoBehaviour
{
    private CubeBehaviour cubeBehaviourComponent;
    public InputActionReference rotateLeft, rotateRight, stopRotation;

    private void Start()
    {
        cubeBehaviourComponent = gameObject.GetComponent<CubeBehaviour>();
    }
    void Update()
    {
        bool isRotatingLeft = rotateLeft.action.IsPressed();
        bool isRotatingRight = rotateRight.action.IsPressed();

        if (isRotatingLeft)
        {
            cubeBehaviourComponent.RotateCounterclockwise();
        }
        else if (isRotatingRight) { 
            cubeBehaviourComponent.RotateClockwise();
        }

        if (cubeBehaviourComponent.RotationSpeed != 0)
        {
            cubeBehaviourComponent.UpdateRotation();
        }
    }

    private void OnEnable()
    {
        stopRotation.action.started += StopRotation;
    }

    private void OnDisable()
    {
        stopRotation.action.started -= StopRotation;
    }

    private void StopRotation(InputAction.CallbackContext obj)
    {
        cubeBehaviourComponent.StopRotation();
    }
}