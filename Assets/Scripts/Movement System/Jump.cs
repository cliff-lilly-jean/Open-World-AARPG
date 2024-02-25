using UnityEngine;

public class Jump : MonoBehaviour
{
    public PlayerController controller;
    public MovementSystemSO movementSystem;

    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();

        // Gravity
        if (!movementSystem.jump.isGrounded && !movementSystem.isJumping)
        {
            if (controller._rb.velocity.y < 0.1)
            {
                Debug.Log("Down");
                ApplyGravity();
            }
        }
    }

    private void ApplyGravity()
    {
        controller._rb.AddForce(Vector3.down * movementSystem.gravityForceMultiplier * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void GroundCheck()
    {
        // Create a capsule buffer from the ground
        movementSystem.groundCheck = (GetComponent<CapsuleCollider>().height / 2) + movementSystem.bufferDistance;

        //Perform a raycast down
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.up, out hit, movementSystem.groundCheck))
        {
            // If grounded, Run the jump action
            movementSystem.isGrounded = true;
        }
        else
        {
            // Don't allow Jump action
            movementSystem.isGrounded = false;
        }
    }

    public void ApplyForce()
    {

        controller._rb.AddForce(Vector3.up * movementSystem.jumpStrength * movementSystem.force, ForceMode.Impulse);

    }
}


