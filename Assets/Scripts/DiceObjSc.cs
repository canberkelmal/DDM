using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.Arm;
using Sirenix.OdinInspector;
using System;
using Unity.VisualScripting;

public class DiceObjSc : MonoBehaviour
{
    GameManager gameManager;
    int currentSpreadShape = 0;    
    Vector3[][] previewPos;
    int numberOfSpreads;
    public DiceCanvasSc diceCanvasSc;

    public Transform[] previewCubes = new Transform[6];
    public DiceSpreads spreads;

    [Serializable]
    public struct DiceSpreads
    {
        public Vector3[] spread1, spread2, spread3;
    }

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        numberOfSpreads = typeof(DiceSpreads).GetFields().Length;
        previewPos = new Vector3[numberOfSpreads][];
        SetSpreadArray();
    }

    // Move dice if the dice is active and mouse0/finger is pressed on tiles
    public void GetMouse0Event()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            diceCanvasSc.GetDiceCamMoveEvent();
            if (Physics.Raycast(ray, out hit, 100, gameManager.tilesLayerMask))
            {
                MoveDice(hit.collider.transform.position);
            }
        }

    }
    void MoveDice(Vector3 hitPoint)
    {
        transform.position = new Vector3(hitPoint.x, transform.position.y, hitPoint.z);
    }

    public void RotateDice()
    {
        transform.localEulerAngles -= Vector3.up * 90f;
    }

    public void MirrorDice()
    {
        Vector3[] setSpreadArray = previewPos[currentSpreadShape];

        for (int i = 0; i < setSpreadArray.Length; i++)
        {
            setSpreadArray[i].z *= -1;
            previewCubes[i].localPosition = setSpreadArray[i];
        }
    }

    public void ChangeDiceSpread()
    {
        if(currentSpreadShape < numberOfSpreads - 1)
        {
            currentSpreadShape++;
        }
        else
        {
            currentSpreadShape = 0;
        }

        Vector3[] setSpreadArray = previewPos[currentSpreadShape];

        for(int i = 0; i < setSpreadArray.Length; i++)
        {
            previewCubes[i].localPosition = setSpreadArray[i];
        }
    }

    void SetSpreadArray()
    {
        for(int i = 0; i < numberOfSpreads; i++)
        {
            previewPos[i] = (Vector3[])typeof(DiceSpreads).GetFields()[i].GetValue(spreads);
        }
    }
}
