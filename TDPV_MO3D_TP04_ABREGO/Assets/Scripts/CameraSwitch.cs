using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] GameObject switchCameraButon, nextCameraPositionButton;
    [SerializeField] Camera mainCamera, secondaryCamera;
    [SerializeField] List<GameObject> cameraPositions;
    int currentPosition = 0;

    // Start is called before the first frame update
    void Start()
    {
        updateCameraPosition();
    }

    public void switchCamera()
    {
        if (mainCamera.enabled)
        {
            mainCamera.enabled = false;
            secondaryCamera.enabled = true;
            nextCameraPositionButton.SetActive(true);
        }
        else
        {
            mainCamera.enabled = true;
            secondaryCamera.enabled = false;
            nextCameraPositionButton.SetActive(false);
        }
    }

    public void nextCameraPosition()
    {
        currentPosition = currentPosition == cameraPositions.Count - 1 ? 0 : currentPosition + 1;

        updateCameraPosition();
    }

    private void updateCameraPosition()
    {
        secondaryCamera.transform.position = cameraPositions[currentPosition].transform.position;
        secondaryCamera.transform.rotation = cameraPositions[currentPosition].transform.rotation;
    }
}
