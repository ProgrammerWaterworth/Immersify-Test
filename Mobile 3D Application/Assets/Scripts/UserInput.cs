using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    //Object Selection
    IObjectInteractable selectedObject;

    [Header("Touch Control Variables")]
    [Tooltip("The amount by which a drag action affects selected objects rotation.")] [SerializeField] float oneToughDragMagnitude;
    [Tooltip("The amount by which a drag action affects selected objects scale.")] [SerializeField] float twoTouchDragMagnitude;
    float twoTouchFingerDistance; //Distance between two fingers touching the screen.



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
                    var _interactable = _hit.transform.GetComponentInParent<IObjectInteractable>();

                    if (_interactable != null)
                    {
                        selectedObject = _interactable;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Updates Rotation of the current selected object using touch input.
    /// </summary>
    void DragTouchAcrossScreen()
    {
        if (Input.touchCount ==1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved && selectedObject != null)
            {
                selectedObject.Rotate(Input.GetTouch(0).deltaPosition * oneToughDragMagnitude);
            }

           
        }else if (Input.touchCount > 1)
        {
            if (selectedObject != null)
            {
                Vector2 _touchSeperation = Input.GetTouch(0).position - Input.GetTouch(1).position;

                //Don't scale from last two finger touch point.
                if (Input.GetTouch(1).phase != TouchPhase.Began)
                {
                    selectedObject.Scale((_touchSeperation.magnitude - twoTouchFingerDistance) * Time.deltaTime * twoTouchDragMagnitude);
                }

                twoTouchFingerDistance = _touchSeperation.magnitude;
            }

        }
    }
}
