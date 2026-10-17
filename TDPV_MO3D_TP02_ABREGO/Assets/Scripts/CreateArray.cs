using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateArray : MonoBehaviour
{
    [SerializeField][Min(0)] private int columns;
    [SerializeField][Min(0)] private int rows;
    [SerializeField] private GameObject brickObject;

    private Renderer cubeRenderer;
    private Renderer sphereRenderer;

    private void Start()
    {
        GetPrefabChildsRenderers();

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject newBrick = Instantiate(brickObject, CalculateBrickPosition(i, j), Quaternion.identity);
            }
        }
    }

    private void GetPrefabChildsRenderers()
    {
        cubeRenderer = brickObject.GetComponentInChildren<MeshRenderer>();
        sphereRenderer = brickObject.GetComponentInChildren<SphereCollider>().GetComponent<Renderer>();
    }

    private Vector3 CalculateBrickPosition(int column, int row)
    {
        float x = (cubeRenderer.bounds.size.x + sphereRenderer.bounds.size.x) * column;
        float y = (cubeRenderer.bounds.size.y) * row;
        float z = 0;

        return new Vector3(x, y, z);
    }
}