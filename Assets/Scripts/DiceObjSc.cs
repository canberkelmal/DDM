using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.Arm;
using Sirenix.OdinInspector;
using System;

public class DiceObjSc : MonoBehaviour
{
    GameManager gameManager;
    int spreadShape = 0;
    
    Transform[] previewCubes = new Transform[6];
    Vector3[][] previewPos = new Vector3[3][];

    public DiceSpreads spreads;

    [Serializable]
    public struct DiceSpreads
    {
        public Vector3[] spread1, spread2, spread3;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        // Move dice if the dice is active and mouse0/finger is pressed on tiles
        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, gameManager.tilesLayerMask))
                {
                    MoveDice(hit.collider.transform.position);
                }
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

    public void ChangeDiceSpread()
    {
        if(spreadShape < 2)
        {
            spreadShape++;
        }
        else
        {
            spreadShape = 0;
        }

        switch(spreadShape)
        {
            //case 0:

        }
    }
}
