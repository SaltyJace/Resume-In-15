using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MakeToastInteractable : Interactable
{
    [SerializeField]
    private GameObject toast;

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Use this function to make any type of interaction
    /// </summary>
    protected override void Interact()
    {
        toast.SetActive(true);
        toast.layer = 6;
        _audio.Play();
        gameObject.layer = 0;
    }
}
