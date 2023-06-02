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

            // Yatay d�n�� hesaplamas�
            float rotationY = mouseX * rotationSpeed;
            Vector3 yRotation = new Vector3(0f, rotationY, 0f);

            // Dikey d�n�� hesaplamas�
            float rotationX = -mouseY * rotationSpeed;
            Vector3 xRotation = new Vector3(rotationX, 0f, 0f);

            // Sadece x ve y rotasyonlar�n� g�ncelleme
            Vector3 finalRotation = transform.localEulerAngles + yRotation + xRotation;

            transform.localEulerAngles = finalRotation;
        }

        float scrollInput = Input.GetAxis("Mouse ScrollWheel"); // Fare tekerle�i hareketi

        // Tekerlek hareketine ba�l� olarak local z pozisyonunu g�ncelleme
        float movementAmount = scrollInput * zoomSpeed * Time.deltaTime;
        camera.transform.localPosition += new Vector3(0f, 0f, movementAmount);
    }
}
