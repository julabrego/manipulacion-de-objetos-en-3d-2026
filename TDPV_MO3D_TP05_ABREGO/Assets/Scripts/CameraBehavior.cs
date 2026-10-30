using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float screenLeftLimit, screenRightLimit;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = target.transform.position.x <= screenLeftLimit
                ? 0
                : target.transform.position.x >= screenRightLimit
                ? screenRightLimit
                : target.transform.position.x;
            newPosition.y = target.transform.position.y;
            transform.position = newPosition;
        }

    }
}
