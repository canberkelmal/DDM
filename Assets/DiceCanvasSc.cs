using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiceCanvasSc : MonoBehaviour
{
    public Transform cam;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(cam);
    }
}
