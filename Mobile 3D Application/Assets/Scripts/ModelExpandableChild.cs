using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModelExpandableChild : MonoBehaviour
{
    Vector3 collapsedPosition;
    [SerializeField] Vector3 expandedTransformation;

    Vector3 startingPosition, textObjectOffset;

    Canvas objectNameTextGUICanvas;  
    TextMeshProUGUI objectNameTextGUI;
    

    private void Start()
    {
        collapsedPosition = transform.localPosition;
        textObjectOffset = new Vector3(.05f,.01f,.06f);
    }

    /// <summary>
    /// Updates the position of the object part to suit the expansion of the parent expandable model.
    /// </summary>
    /// <param name="_expansionMagnitude"></param>
    public void UpdatePosition(float _expansionMagnitude)
    {
        transform.localPosition =  Vector3.Lerp(collapsedPosition, collapsedPosition + expandedTransformation, _expansionMagnitude);
    }

    private void Update()
    {
        UpdateObjectNamePosition();
    }

    /// <summary>
    /// Updates the position of the canvas to face the camera.
    /// </summary>
    void UpdateObjectNamePosition()
    {
        if (objectNameTextGUI != null)
        {
            objectNameTextGUICanvas.transform.LookAt(Camera.main.transform);
        }
    }

    /// <summary>
    /// Creates an canvas instance to display the objects name on.
    /// </summary>
    void CreateTextCanvas()
    {
        objectNameTextGUICanvas = Resources.Load<Canvas>("PartCanvas");

        if(objectNameTextGUICanvas==null)
        {
            Debug.LogError("Cannot find objectNameTextGUIPrefab: PartCanvas.");
            return;
        }

        startingPosition = transform.position;
        //Get object collider for centre point
        if (GetComponent<Collider>() != null)
            startingPosition = GetComponent<Collider>().bounds.center;


        Canvas canvas = Instantiate(objectNameTextGUICanvas, startingPosition + textObjectOffset, Quaternion.identity, null);
        canvas.transform.parent = transform;
        objectNameTextGUICanvas = canvas;
        if (canvas.GetComponentInChildren<TextMeshProUGUI>() != null)
        {
            objectNameTextGUI = canvas.GetComponentInChildren<TextMeshProUGUI>();
            //Set name of the part.
            objectNameTextGUI.text = "";
        }
    }

    /// <summary>
    /// Set the name of this expandable model part.
    /// </summary>
    /// <param name="_name"></param>
    public void SetPartName(string _name)
    {
        CreateTextCanvas();
        objectNameTextGUI.text = _name;
    }
}
