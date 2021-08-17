using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandableModel : MonoBehaviour, IObjectInteractable
{
    public void Rotate(Vector2 _rotation)
    {
        transform.Rotate(Camera.main.transform.right, _rotation.y, Space.World);
        transform.Rotate(Camera.main.transform.up, -_rotation.x, Space.World);
    }

    public void Scale(float _deltaScale)
    {
        transform.localScale += Vector3.one * _deltaScale;
    }
}
