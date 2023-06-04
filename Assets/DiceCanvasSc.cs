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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = dice.position + Vector3.up*offset.y;
        transform.LookAt(cam);
    }
}
