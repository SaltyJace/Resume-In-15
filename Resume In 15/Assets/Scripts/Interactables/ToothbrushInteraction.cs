using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothbrushInteraction : Interactable
{
    [SerializeField]
    private AudioSource _audio;

    /// <summary>
    /// Use this function to make any type of interaction
    /// </summary>
    protected override void Interact()
    {
        _audio.Play();
        gameObject.layer = 0;
    }
}
