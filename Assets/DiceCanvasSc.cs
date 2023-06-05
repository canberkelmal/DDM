using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiceCanvasSc : MonoBehaviour
{
    public Transform cam;
    public Transform dice;

    Vector3 offset;

    private void Start()
    {
        offset = transform.position - dice.position;
        GetDiceCamMoveEvent();
    }

    public void GetDiceCamMoveEvent()
    {
        transform.position = dice.position + Vector3.up * offset.y;

        LookButtonsToCamera();
    }

    void LookButtonsToCamera()
    {
        /*for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).LookAt(cam);
            transform.GetChild(i).rotation *= Quaternion.Euler(0, 180 ,0);
        }*/
        transform.GetChild(0).LookAt(cam);
        //transform.GetChild(0).rotation *= Quaternion.Euler(0, 180, 0);

    }
}
