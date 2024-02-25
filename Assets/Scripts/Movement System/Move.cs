using UnityEngine;

public class Move : MonoBehaviour
{
    public PlayerController controller;
    public MovementSystemSO movementSystem;
    public Transform lookCamera;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // Move
        if (movementSystem.moveDirection.sqrMagnitude == 0) return;
        Walk();
    }

    public void Walk()
    {

        // Get input
        movementSystem.moveDirection = controller.controls.Gameplay.Move.ReadValue<Vector2>();

        // Get direction angles
        var lookDirection = Mathf.Atan2(movementSystem.moveDirection.x, movementSystem.moveDirection.y) * Mathf.Rad2Deg + lookCamera.eulerAngles.y;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, lookDirection, ref movementSystem.currentMoveVelocity, movementSystem.lookDirectionSmoothTime);

        // Rotate the transform in the lookDirection
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        // Move the player in the direction of the rotation
        Vector3 moveDirection = Quaternion.Euler(0f, lookDirection, 0f) * Vector3.forward;
        controller._rb.AddForce(moveDirection * movementSystem.moveSpeed * movementSystem.force);

    }

    public void Run()
    {
        // return _isSprinting = context.performed ? true : false;
        Debug.Log("Sprint");
        movementSystem.isSprinting = true;
        movementSystem.moveSpeed += movementSystem.moveSpeedBoost;
        Debug.Log("Current Speed pressed: " + movementSystem.moveSpeed);
    }

    public void RunCanceled()
    {
        Debug.Log("Canceled");
        movementSystem.isSprinting = false;
        movementSystem.moveSpeed = movementSystem.defaultMoveSpeed;
        Debug.Log("Current Speed not pressed: " + movementSystem.moveSpeed);
    }
}
