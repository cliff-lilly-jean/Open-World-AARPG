using UnityEngine;

public class JumpController : MonoBehaviour
{
    public PlayerController controller;
    public MovementSystem movementSystem;

    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();

        // Gravity
        if (!movementSystem.jump.isGrounded)
        {
            if (controller._rb.velocity.y < 0.1)
            {
                ApplyGravity();
            }
        }


    }

    private void ApplyGravity()
    {
        controller._rb.AddForce(Vector3.down * movementSystem.jump.gravityForceMultiplier * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void GroundCheck()
    {
        // Create a capsule buffer from the ground
        movementSystem.jump.groundCheck = (GetComponent<CapsuleCollider>().height / 2) + movementSystem.jump.bufferDistance;

        //Perform a raycast down
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.up, out hit, movementSystem.jump.groundCheck))
        {
            // If grounded, Run the jump action
            movementSystem.jump.isGrounded = true;
        }
        else
        {
            // Don't allow Jump action
            movementSystem.jump.isGrounded = false;
        }
    }

    public void Activate()
    {
        controller._rb.AddForce(Vector3.up * movementSystem.jump.jumpStrength * movementSystem.force, ForceMode.Impulse);
    }
}


