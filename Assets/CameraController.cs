using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 5f; // Rotation speed
    public float zoomSpeed = 5f; // Zoom speed

    private GameObject _mainCam;

    private void Start()
    {
        _mainCam = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        // Rotate platform if the mouse button 0 held down.
        if (Input.GetMouseButton(0))
        {
            SetCameraRotation();
        }

        // Zoom if the mouse wheel is turning
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            SetZoom();
        }
    }

    // Rotate platform
    void SetCameraRotation()
    {
        // Get mouse axis's move amounts
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Set rotation amounts
        float rotationY = mouseX * rotationSpeed;
        float rotationX = -mouseY * rotationSpeed;
        Vector3 newRotation = new Vector3(rotationX, rotationY, 0f);

        // Rotate the platform
        transform.localEulerAngles += newRotation;
    }

    // Move camera on local z axis according to scroll input
    void SetZoom()
    {
        // Get scroll wheel value
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Set move amount
        float movementAmount = scrollInput * zoomSpeed * Time.deltaTime;

        // Move the camera
        _mainCam.transform.localPosition += new Vector3(0f, 0f, movementAmount);
    }
}
