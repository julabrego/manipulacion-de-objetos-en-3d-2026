
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CameraConfigurator : MonoBehaviour
{
    [SerializeField] GameObject projectionTogglerButtonText, orthographicConfiguratorGameObject, pespectiveConfiguratorGameObject;
    [SerializeField] Slider fovSlider, sizeSlider, ncpSlider, fcpSlider;
    [SerializeField] Camera mainCamera;

    bool orthographicProjection;
    [Range(0, 180)] float fov;
    [Range(0, 100)] float orthographicSize;
    [Range(0, 100)] float nearClipPlane;
    [Range(0, 1000)] float farClipPlane;

    private void Start()
    {
        if (mainCamera != null)
        {
            orthographicProjection = mainCamera.orthographic;
            fov = mainCamera.fieldOfView;
            fovSlider.SetValueWithoutNotify(fov);
            orthographicSize = mainCamera.orthographicSize;
            sizeSlider.SetValueWithoutNotify(orthographicSize);
            nearClipPlane = mainCamera.nearClipPlane;
            ncpSlider.SetValueWithoutNotify(nearClipPlane);
            farClipPlane = mainCamera.farClipPlane;
            fcpSlider.SetValueWithoutNotify(farClipPlane);

            Debug.Log(orthographicProjection);
            Debug.Log(orthographicSize);
            Debug.Log(fov);
            Debug.Log(orthographicSize);
            Debug.Log(nearClipPlane);
            Debug.Log(farClipPlane);
        }
        updateGUIElements();
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, new Vector3(GetComponent<Camera>().aspect, 1.0f, 1.0f));
        Gizmos.DrawFrustum(Vector3.zero, GetComponent<Camera>().fieldOfView, GetComponent<Camera>().farClipPlane, GetComponent<Camera>().nearClipPlane, 1.0f);
    }

    public void toggleCameraProjection()
    {
        orthographicProjection = mainCamera.orthographic = !orthographicProjection;
        updateGUIElements();
    }

    public void updateSize(float _value)
    {
        orthographicSize = mainCamera.orthographicSize = _value;
        sizeSlider.SetValueWithoutNotify(orthographicSize);
    }

    public void updateFov(float _value)
    {
        fov = mainCamera.fieldOfView = _value;
        fovSlider.SetValueWithoutNotify(fov);
    }

    public void updateNcp(float _value)
    {
        nearClipPlane = mainCamera.nearClipPlane = _value;
        ncpSlider.SetValueWithoutNotify(nearClipPlane);
    }
    public void updateFcp(float _value)
    {
        farClipPlane = mainCamera.farClipPlane = _value;
        fcpSlider.SetValueWithoutNotify(farClipPlane);
    }

    private void updateGUIElements()
    {
        orthographicConfiguratorGameObject.SetActive(orthographicProjection);
        pespectiveConfiguratorGameObject.SetActive(!orthographicProjection);
        projectionTogglerButtonText.GetComponent<TextMeshProUGUI>().text = orthographicProjection ? "Orthographic" : "Perspective";
    }
}
