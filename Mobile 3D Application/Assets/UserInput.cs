using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    //Object Selection
    GameObject selectedObject;

    [Header("Touch Control Variables")]
    [Tooltip("The amount by which a drag action affects selected objects rotation.")][SerializeField] float dragMagnitude;
    Vector2 startingTouchPosition;
    


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

                    Debug.Log("Selected: " + selectedObject);

                    startingTouchPosition = Input.GetTouch(0).position;
                }

            }
        }
    }

    void DragTouchAcrossScreen()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                selectedObject.transform.eulerAngles += new Vector3(Input.GetTouch(0).deltaPosition.y, -Input.GetTouch(0).deltaPosition.x, 0) *dragMagnitude;
            }
        }
    }


    void Release()
    {

    }
}
