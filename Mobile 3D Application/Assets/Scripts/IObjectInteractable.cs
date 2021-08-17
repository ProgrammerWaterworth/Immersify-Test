using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectInteractable
{

    /// <summary>
    /// Rotate the object.
    /// </summary>
    /// <param name="_rotationInput">A vector containing two rotations relative to the users view.</param>
    void Rotate(Vector2 _rotationInput);

    /// <summary>
    /// Scale the object.
    /// </summary>
    /// <param name="_scale">The magnitude in which to uniformly scale the object to.</param>
    void Scale(float _scale);

}
