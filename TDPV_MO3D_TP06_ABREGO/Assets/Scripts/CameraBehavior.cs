using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    [SerializeField] GameObject target;
    float targetDistance;

    void Start()
    {
        targetDistance = transform.position.z - target.transform.position.z;
    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, target.transform.position.z + targetDistance);
    }
}
