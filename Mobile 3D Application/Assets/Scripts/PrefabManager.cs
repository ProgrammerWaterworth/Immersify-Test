using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages which of the prefabs are currently active.
/// </summary>
public class PrefabManager : MonoBehaviour
{
    [SerializeField] GameObject car, engine;


    public void SetCarActive()
    {
        if (car!=null)
            car.SetActive(true);
        if (engine != null)
            engine.SetActive(false);
    }

    public void SetEngineActive()
    {
        if (car != null)
            car.SetActive(false);
        if (engine != null)
            engine.SetActive(true);
    }
}
