using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.Arm;

public class DiceObjSc : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        // Move dice if the dice is active and mouse0/finger is pressed on tiles
        /*if (Input.GetMouseButton(0))
        {            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit, 100, gameManager.UILayerMask) && Physics.Raycast(ray, out hit, 100, gameManager.tilesLayerMask))
            {
                MoveDice(hit.collider.transform.position);
            }
        }*/

        /*if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, gameManager.tilesLayerMask))
            {
                Button button = hit.collider.GetComponent<Button>();
                if (button == null)
                {
                    MoveDice(hit.collider.transform.position);
                }
                else
                {
                    button.onClick.Invoke();
                }
            }
        }*/

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

        /*if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = gameManager.tilesLayerMask & ~LayerMask.GetMask("UI"); // "UI" katmanýný hariç tut

            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                MoveDice(hit.collider.transform.position);
            }
        }*/
    }
    void MoveDice(Vector3 hitPoint)
    {
        transform.position = new Vector3(hitPoint.x, transform.position.y, hitPoint.z);
    }

    public void RotateDice()
    {
        transform.localEulerAngles -= Vector3.up * 90f;
    }
}
