using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelExpandableChild : MonoBehaviour
{
    Vector3 collapsedPosition;
    [SerializeField] Vector3 expandedTransformation;

    private void Start()
    {
        collapsedPosition = transform.position;
    }

    public void UpdatePosition(float _expansionMagnitude)
    {
        transform.localPosition =  Vector3.Lerp(collapsedPosition, collapsedPosition + expandedTransformation, _expansionMagnitude);
    }
}
