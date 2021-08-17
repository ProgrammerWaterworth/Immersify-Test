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
    /// Scale the object up or down.
    /// </summary>
    /// <param name="_deltaScale">The change in object scale in which to uniformly scale the object by.</param>
    void Scale(float _deltaScale);

}
