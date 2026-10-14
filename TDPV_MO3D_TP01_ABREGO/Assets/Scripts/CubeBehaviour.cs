using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    [SerializeField][Range(-1, 1)] private float rotationSpeed;

    public float RotationSpeed { get => rotationSpeed; }


    public void StopRotation()
    {
        rotationSpeed = 0;
    }

    public void RotateClockwise()
    {
        rotationSpeed = -1;
    }

    public void RotateCounterclockwise()
    {
        rotationSpeed = 1;
    }

    public void UpdateRotation()
    {
        transform.Rotate(0f, 0f, rotationSpeed);
    }
}