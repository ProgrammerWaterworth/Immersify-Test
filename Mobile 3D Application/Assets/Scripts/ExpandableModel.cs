using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandableModel : MonoBehaviour, IObjectInteractable
{
    bool expanded;
    List<ExpandableComponent> childObjects;

    [Header("Expansion")]
    [SerializeField][Tooltip("The magnitude at which a child component of this object will expand outwards relative to the starting position and origin.")] float expansionMagnitude;

    struct ExpandableComponent
    {
        public Transform expandableObject;
        public Vector3 startPosition;
        public Vector3 endPosition;

        public ExpandableComponent(Transform _expandableComponent, Vector3 _startPos, Vector3 _endPos)
        {
            expandableObject = _expandableComponent;
            startPosition = _startPos;
            endPosition = _endPos;
        }
    }

    private void Start()
    {
        //SetChildObjectParts();
    }

    public void Rotate(Vector2 _rotation)
    {    
        transform.Rotate(Camera.main.transform.right, _rotation.y, Space.World);
        transform.Rotate(Camera.main.transform.up, -_rotation.x, Space.World);
    }

    public void Scale(float _deltaScale)
    {
        transform.localScale += Vector3.one * _deltaScale;
    }

    /// <summary>
    /// Expands object to a state where each sub component is seperated by space.
    /// </summary>
    void ExpandObject()
    {
        //To expand the object each component must have a starting and end position to lerp between.
        //Using the natural starting position we can expand into a direction using the axis in which
        //the object is most alligned and expanding to a point proportional to the natural starting
        //position from centre.

        //foreach (ExpandableComponent _childObject in childObjects)
     
    }

    /// <summary>
    /// Set the child objects that make up this object.
    /// </summary>
    void SetChildObjectParts()
    {
        List<ExpandableComponent> childObjects = new List<ExpandableComponent>();

        Transform[] childTransforms = GetComponentsInChildren<Transform>();

        foreach(Transform _transform in childTransforms)
        {
            //Get the localPosition of object when expanded but using original world scale.


            //childObjects.Add(new ExpandableComponent(_transform, _transform.localPosition, )
        }

        childObjects.AddRange(GetComponentsInChildren<ExpandableComponent>());
    }

    /// <summary>
    /// Collapses object into a state where it is put together.
    /// </summary>
    void CollapseObject()
    { 
        
    }

    public void Interact()
    {
        if (expanded)
            CollapseObject();
        else
            ExpandObject();
    }
}
