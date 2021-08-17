using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandableModel : MonoBehaviour, IObjectInteractable
{
    bool expanded;
    List<ModelExpandableChild> childObjects;

    Coroutine expandCoroutine;

    float expansionMagnitude;
    [SerializeField] float expansionRate;
    [SerializeField] float collapseRate;

    private void Start()
    {
        SetChildObjectParts();
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
    /// Set the child objects that make up this object.
    /// </summary>
    void SetChildObjectParts()
    {
        childObjects = new List<ModelExpandableChild>();
        childObjects.AddRange(GetComponentsInChildren<ModelExpandableChild>());
    }



    public void Interact()
    {
        Debug.Log("Interact");

        if (expandCoroutine != null)
            StopCoroutine(expandCoroutine);

        expanded = !expanded;

        if (expanded)
            expandCoroutine = StartCoroutine(CollapseObject());
        else
            expandCoroutine = StartCoroutine(ExpandObject());
    }

    /// <summary>
    /// Expands object to a state where each sub component is seperated by space.
    /// </summary>
    IEnumerator ExpandObject()
    {
        while (expansionMagnitude < 1)
        {
            expansionMagnitude += expansionRate*Time.deltaTime;
            UpdateChildModels();
            yield return new WaitForEndOfFrame();

        }
        expansionMagnitude = 1;
        yield return null;
    }

    /// <summary>
    /// Collapses object into a state where it is put together.
    /// </summary>
    IEnumerator CollapseObject()
    {
        while (expansionMagnitude > 0)
        {
            expansionMagnitude -= collapseRate*Time.deltaTime;
            UpdateChildModels();
            yield return new WaitForEndOfFrame();
        }
        expansionMagnitude = 0;
        yield return null;
    }

    /// <summary>
    /// Update expansion position of each child model of the current gameobject.
    /// </summary>
    void UpdateChildModels()
    {
        foreach (ModelExpandableChild _child in childObjects)
        {
           
            if(_child!=null)
                _child.UpdatePosition(expansionMagnitude);
        }
    }
}
