using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera _camera;

    private float x_Rotation = 0f;

    //Controls how fast camera will move per frame
    public float mouseSensitivity = 100f;

    //Extra Camera Properties
    public float fov = 60f;
    public bool cameraCanMove = true; //for later?
    public float maxLookAngle = 80f;

    private PlayerMovement playerMovement;
    public bool enableHeadBob = true;
    public Transform joint;
    public float bobSpeed = 10f;
    public Vector3 bobAmount = new Vector3(.15f, .05f, 0f);

    private Vector3 jointOriginalPos;
    private float timer = 0;

    private void Start()
    {
        //Don't display mouse cursor when testing/playing
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void CameraLook(Vector2 input)
    {
        _camera.fieldOfView = fov;
        float mouse_x = input.x * Time.deltaTime;
        float mouse_y = input.y * Time.deltaTime;

        //Rotation of Camera (up/down)
        x_Rotation -= mouse_y * mouseSensitivity;
        x_Rotation = Mathf.Clamp(x_Rotation, -maxLookAngle, maxLookAngle);

        //Camera Transform
        _camera.transform.localRotation = Quaternion.Euler(x_Rotation, 0f, 0f);

        //Rotate Player when looking 
        transform.Rotate(Vector3.up * mouse_x * mouseSensitivity);

        if (enableHeadBob)
        {
            HeadBob();
        }
    }

    private void HeadBob()
    {
        if (playerMovement.IsMoving())
        {
            // Calculates HeadBob speed during walking
            timer += Time.deltaTime * bobSpeed;
            // Applies HeadBob movement
            joint.localPosition = new Vector3(jointOriginalPos.x + Mathf.Sin(timer) * bobAmount.x, jointOriginalPos.y + Mathf.Sin(timer) * bobAmount.y, jointOriginalPos.z + Mathf.Sin(timer) * bobAmount.z);
        }
        else
        {
            // Resets when play stops moving
            timer = 0;
            joint.localPosition = new Vector3(Mathf.Lerp(joint.localPosition.x, jointOriginalPos.x, Time.deltaTime * bobSpeed), Mathf.Lerp(joint.localPosition.y, jointOriginalPos.y, Time.deltaTime * bobSpeed), Mathf.Lerp(joint.localPosition.z, jointOriginalPos.z, Time.deltaTime * bobSpeed));
        }
    }
}
