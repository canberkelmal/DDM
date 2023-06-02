using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 5f; // Rotation speed
    public float zoomSpeed = 5f; // Zoom speed

    GameObject camera;
    private Vector3 initialRotation;

    private void Start()
    {
        initialRotation = transform.localEulerAngles;
        camera = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X"); 
            float mouseY = Input.GetAxis("Mouse Y"); 

            // Yatay dönüþ hesaplamasý
            float rotationY = mouseX * rotationSpeed;
            Vector3 yRotation = new Vector3(0f, rotationY, 0f);

            // Dikey dönüþ hesaplamasý
            float rotationX = -mouseY * rotationSpeed;
            Vector3 xRotation = new Vector3(rotationX, 0f, 0f);

            // Sadece x ve y rotasyonlarýný güncelleme
            Vector3 finalRotation = transform.localEulerAngles + yRotation + xRotation;

            transform.localEulerAngles = finalRotation;
        }

        float scrollInput = Input.GetAxis("Mouse ScrollWheel"); // Fare tekerleði hareketi

        // Tekerlek hareketine baðlý olarak local z pozisyonunu güncelleme
        float movementAmount = scrollInput * zoomSpeed * Time.deltaTime;
        camera.transform.localPosition += new Vector3(0f, 0f, movementAmount);
    }
}
