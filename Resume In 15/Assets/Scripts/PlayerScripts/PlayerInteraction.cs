using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Camera _camera;

    [SerializeField]
    private float distance = 5f; //distance between player and interactable

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<PlayerCamera>()._camera; //grab current camera
        playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ensure it stays empty when not colliding
        playerUI.UpdateText(string.Empty);

        //Raycast
        CreateRaycast(distance);

        //Interaction
        //PlayerInteract(hit);
    }

    private void CreateRaycast(float length)
    {
        //Center cast in camera
        RaycastHit hit;
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        if (Physics.Raycast(ray, out hit, length, mask))
        {
            if (hit.collider.GetComponent<Interactable>() != null)
            {
                playerUI.UpdateText(hit.collider.GetComponent<Interactable>().prompt);
            }
        }

        //return hit;
    }

    //private void PlayerInteract(RaycastHit hit)
    //{
    //    if (hit.collider.GetComponent<Interactable>() != null)
    //    {
    //        Debug.Log(hit.collider.GetComponent<Interactable>().prompt);
    //    }
    //}
}
