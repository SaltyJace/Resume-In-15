using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnGroundActions onGroundActions;

    private PlayerMovement movement;
    private PlayerCamera cam;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onGroundActions = playerInput.OnGround;
        movement = GetComponent<PlayerMovement>();
        cam = GetComponent<PlayerCamera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.Movement(onGroundActions.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        cam.CameraLook(onGroundActions.CameraLook.ReadValue<Vector2>());
    }

    #region Enable or Disable Movement
    private void OnEnable()
    {
        onGroundActions.Enable();
    }
    
    private void OnDisable()
    {
        onGroundActions.Disable();
    }
    #endregion
}
