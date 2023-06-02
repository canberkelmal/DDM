using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Title("Scene objects")]
    [TabGroup("Objs")]
    public GameObject cameraPlatform;
    [TabGroup("Objs")]
    public GameObject dice;

    public LayerMask tilesLayerMask;


    private CameraController _cameraControllerSc;
    private bool diceActive;

    // Start is called before the first frame update
    void Awake()
    {
        _cameraControllerSc = cameraPlatform.GetComponent<CameraController>();
        diceActive = dice.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        InputController();        
    }

    void InputController()
    {
        RaycastHit hit;

        if (diceActive && Input.GetMouseButton(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, tilesLayerMask))
        {
            moveDice(hit.collider.transform.position);
        }
        // Rotate platform if the mouse button 0 held down.
        else if (!diceActive && Input.GetMouseButton(0))
        {
            _cameraControllerSc.SetCameraRotation();
        }

        // Zoom if the mouse wheel is turning
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            _cameraControllerSc.SetZoom();
        }
    }

    void moveDice(Vector3 hitPoint)
    {
        dice.transform.position = new Vector3(hitPoint.x, dice.transform.position.y, hitPoint.z);
    }

    public void Dice()
    {
        dice.SetActive(!dice.activeSelf);
        diceActive = dice.activeSelf;
    }
}
