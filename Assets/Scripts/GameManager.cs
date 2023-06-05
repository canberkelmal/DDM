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
    public LayerMask UILayerMask;


    private CameraController _cameraControllerSc;
    private DiceObjSc _diceSc;
    private bool _diceActive;
    private Vector3 _defDicePos = Vector3.up;

    // Start is called before the first frame update
    void Awake()
    {
        _cameraControllerSc = cameraPlatform.GetComponent<CameraController>();
        _diceSc = dice.GetComponent<DiceObjSc>();
        _diceActive = dice.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        InputController();        
    }

    void InputController()
    {
        // Rotate platform if the mouse button 0 held down.
        /*if (!_diceActive && Input.GetMouseButton(0))
        {
            _cameraControllerSc.SetCameraRotation();
        }*/
        if (_diceActive && Input.GetMouseButton(0))
        {
            _diceSc.GetMouse0Event();
        }

        if (Input.GetMouseButton(1))
        {
            _cameraControllerSc.SetCameraRotation();
            _diceSc.diceCanvasSc.GetDiceCamMoveEvent();
        }

        // Zoom if the mouse wheel is turning
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            _cameraControllerSc.SetZoom();
        }
    }

    // Hide/Show dice
    public void Dice()
    {
        dice.SetActive(!dice.activeSelf);
        _diceActive = dice.activeSelf;
    }
}
