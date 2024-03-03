using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    PlayerController controller;
    public MovementSystem movementSystem;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        controller.controls.Gameplay.Jump.performed += ctx => Activate(ctx);
    }

    // Update is called once per frame
    void Update()
    {
        // Ground check
        IsGrounded();

        if (!IsGrounded())
        {
            movementSystem.leap.isJumping = false;
            ApplyGravity();
        }
    }

    private void FixedUpdate()
    {


    }

    private void ApplyGravity()
    {
        controller._rb.AddForce(Vector3.down * movementSystem.leap.gravityForceMultiplier * Time.deltaTime, ForceMode.VelocityChange);
    }

    private bool IsGrounded()
    {

        return Physics.Raycast(transform.position, Vector3.down, movementSystem.leap.groundDistance);
    }

    public void Activate(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            controller._rb.AddForce(Vector3.up * movementSystem.leap.jumpStrength * movementSystem.force, ForceMode.Impulse);

            movementSystem.leap.isJumping = true;
        }

    }
}


