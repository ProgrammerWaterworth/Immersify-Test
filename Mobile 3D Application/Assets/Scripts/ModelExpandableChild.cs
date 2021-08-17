using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModelExpandableChild : MonoBehaviour
{
    Vector3 collapsedPosition;
    [SerializeField] Vector3 expandedTransformation;

    [Header("UI")]
    [SerializeField] Vector3 textObjectOffset;

    Canvas objectNameTextGUICanvas;  
    TextMeshProUGUI objectNameTextGUI;
    

    private void Start()
    {
        collapsedPosition = transform.position;        
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

        Canvas canvas = Instantiate(objectNameTextGUICanvas, transform.position, Quaternion.identity, transform);
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
        objectNameTextGUI.name = _name;
    }
}
