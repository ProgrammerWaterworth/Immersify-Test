using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModelExpandableChild : MonoBehaviour
{
    Vector3 collapsedPosition;
    [SerializeField] Vector3 expandedTransformation;

    //[Header("UI")]
    TextMeshProUGUI objectNameTextGUI;

    private void Start()
    {
        collapsedPosition = transform.position;
    }

    public void UpdatePosition(float _expansionMagnitude)
    {
        transform.localPosition =  Vector3.Lerp(collapsedPosition, collapsedPosition + expandedTransformation, _expansionMagnitude);
    }

    private void Update()
    {
        UpdateObjectNamePosition();
    }

    void UpdateObjectNamePosition()
    {
        if(objectNameTextGUI!=null)
            objectNameTextGUI.transform.LookAt(Camera.main.transform);
    }
}
