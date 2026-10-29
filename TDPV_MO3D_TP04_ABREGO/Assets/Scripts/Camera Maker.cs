using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMaker : MonoBehaviour
{
    public void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.color = Color.green;
        Gizmos.DrawCube(Vector3.zero, new Vector3(10f, 10f, 10f));

        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, new Vector3(transform.forward.x, transform.forward.y, transform.forward.z + 180));

    }
}
