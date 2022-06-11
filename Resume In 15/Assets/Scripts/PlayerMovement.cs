using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    public float gravity = -9.8f;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void Movement(Vector2 input)
    {
        //Handle Movement for player
        Vector3 direction = Vector3.zero;
        direction.x = input.x;
        direction.z = input.y;
        controller.Move(transform.TransformDirection(direction) * speed * Time.deltaTime);

        //Ensure player isn't contnously going down even when grounded
        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -5f;
        }

        //Handle gravity of player
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }
}
