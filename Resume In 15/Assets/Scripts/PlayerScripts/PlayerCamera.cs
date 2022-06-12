using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera _camera;

    private float x_Rotation = 0f;

    //Controls how fast camera will move per frame
    public float x_Sensitivity = 80f;
    public float y_Sensitivity = 80f;

    public void CameraLook(Vector2 input)
    {
        float mouse_x = input.x;
        float mouse_y = input.y;

        //Rotation of Camera (up/down)
        x_Rotation -= (mouse_y * Time.deltaTime) * y_Sensitivity;
        x_Rotation = Mathf.Clamp(x_Rotation, -80f, 80f);

        //Camera Transform
        _camera.transform.localRotation = Quaternion.Euler(x_Rotation, 0f, 0f);

        //Rotate Player when looking 
        transform.Rotate(Vector3.up * (mouse_x * Time.deltaTime) * x_Sensitivity);
    }
}
