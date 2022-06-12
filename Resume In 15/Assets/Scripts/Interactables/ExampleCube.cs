using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleCube : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Use this function to make any type of interaction
    /// </summary>
    protected override void Interact()
    {
        Object.Destroy(gameObject); //just destroy cube for now
    }
}
