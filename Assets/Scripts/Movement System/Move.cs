using UnityEngine;

public class Move : MonoBehaviour
{
    public PlayerController controller;
    public MovementSystemSO movementSystem;
    public Transform lookCamera;

    private float _defaultMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        _defaultMoveSpeed = movementSystem.move.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // Move
        if (movementSystem.move.moveDirection.sqrMagnitude == 0) return;
        Walk();
    }

    public void Walk()
    {

        // Get input
        movementSystem.move.moveDirection = controller.controls.Gameplay.Move.ReadValue<Vector2>();

        // Get direction angles
        var lookDirection = Mathf.Atan2(movementSystem.move.moveDirection.x, movementSystem.move.moveDirection.y) * Mathf.Rad2Deg + lookCamera.eulerAngles.y;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, lookDirection, ref movementSystem.move.currentMoveVelocity, movementSystem.move.lookDirectionSmoothTime);

        // Rotate the transform in the lookDirection
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        // Move the player in the direction of the rotation
        Vector3 moveDirection = Quaternion.Euler(0f, lookDirection, 0f) * Vector3.forward;
        controller._rb.AddForce(moveDirection * movementSystem.move.moveSpeed * movementSystem.force);

    }

    public void Run()
    {
        // return _isSprinting = context.performed ? true : false;
        Debug.Log("Sprint");
        movementSystem.move.isSprinting = true;
        movementSystem.move.moveSpeed += movementSystem.move.moveSpeedBoost;
        Debug.Log("Current Speed pressed: " + movementSystem.move.moveSpeed);
    }

    public void RunCanceled()
    {
        Debug.Log("Canceled");
        movementSystem.move.isSprinting = false;
        movementSystem.move.moveSpeed = _defaultMoveSpeed;
        Debug.Log("Current Speed not pressed: " + movementSystem.move.moveSpeed);
    }
}
