using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    //Object Selection
    GameObject selectedObject;

    [Header("Touch Control Variables")]
    [Tooltip("The amount by which a drag action affects selected objects rotation.")][SerializeField] float dragMagnitude;
    


    // Update is called once per frame
    void Update()
    {
        SelectObject();
        DragTouchAcrossScreen();
    }

    /// <summary>
    /// Updates current selected object using user touch input.
    /// </summary>
    void SelectObject()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray _ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit _hit;

                if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
                {                 
                    selectedObject = _hit.transform.root.gameObject;
                }
            }
        }
    }

    /// <summary>
    /// Updates Rotation of the current selected object using touch inpuyt.
    /// </summary>
    void DragTouchAcrossScreen()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved && selectedObject !=null)
            {
                selectedObject.transform.Rotate(Camera.main.transform.right, Input.GetTouch(0).deltaPosition.y * dragMagnitude, Space.World);
                selectedObject.transform.Rotate(Camera.main.transform.up, -Input.GetTouch(0).deltaPosition.x * dragMagnitude, Space.World);
            }
        }
    }

}
