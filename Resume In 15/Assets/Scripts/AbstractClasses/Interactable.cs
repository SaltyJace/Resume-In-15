using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //This will show when player highlights an object 
    public string prompt;

    /// <summary>
    /// Player calls this
    /// </summary>
    public void BaseInteract()
    {
        Interact();
    }

    /// <summary>
    /// Meant to be overwritten by future objects
    /// </summary>
    protected virtual void Interact()
    {
        //Leave Empty
    }
}
