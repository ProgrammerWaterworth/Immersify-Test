using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelExpandableChild : MonoBehaviour
{
    Vector3 collapsedPosition;
    [SerializeField] Vector3 expandedTransformation;

    public void UpdatePosition(float _expansionMagnitude)
    {
        Vector3.Lerp(collapsedPosition, collapsedPosition + expandedTransformation, _expansionMagnitude);
    }
}
