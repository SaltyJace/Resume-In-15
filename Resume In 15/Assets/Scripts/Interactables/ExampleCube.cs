using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExampleCube : Interactable
{
    /// <summary>
    /// Use this function to make any type of interaction
    /// </summary>
    protected override void Interact()
    {
        Object.Destroy(gameObject); //just destroy cube for now
    }
}
