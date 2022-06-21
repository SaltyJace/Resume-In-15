using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantsInteractable : Interactable
{
    [SerializeField]
    private AudioSource _audio;

    /// <summary>
    /// Interact with pants
    /// </summary>
    protected override void Interact()
    {
        _audio.Play();
        //it wont play audio rn ill fix later
        Object.Destroy(gameObject);
    }
}
