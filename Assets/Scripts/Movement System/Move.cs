using UnityEngine;

public class Move : MonoBehaviour
{
    public MovementSystemSO movementSystem;

    private Vector2 _moveDirection;
    public PlayerController controller;

    private float _lookDirectionSmoothTime;
    private float _moveSpeed;
    private float _moveSpeedBoost;

    private float _defaultMoveSpeed;
    private float _currentMoveVelocity;
    private float _moveForceMultiplier = 100;


    private bool _isSprinting;
    bool _sprint;


    public Transform lookCamera;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();

        _defaultMoveSpeed = movementSystem.moveSpeed;
        _moveDirection = movementSystem.moveDirection;
        _lookDirectionSmoothTime = movementSystem.lookDirectionSmoothTime;
        _moveSpeed = movementSystem.moveSpeed;
        _moveSpeedBoost = movementSystem.moveSpeedBoost;
        _currentMoveVelocity = movementSystem.currentMoveVelocity;
        _moveForceMultiplier = movementSystem.force;
        _isSprinting = movementSystem.isSprinting;
        _sprint = movementSystem.sprint;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // Move
        if (_moveDirection.sqrMagnitude == 0) return;
        Walk();
    }

    public void Walk()
    {

        // Get input
        _moveDirection = controller.controls.Gameplay.Move.ReadValue<Vector2>();

        // Get direction angles
        var lookDirection = Mathf.Atan2(_moveDirection.x, _moveDirection.y) * Mathf.Rad2Deg + lookCamera.eulerAngles.y;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, lookDirection, ref _currentMoveVelocity, _lookDirectionSmoothTime);

        // Rotate the transform in the lookDirection
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        // Move the player in the direction of the rotation
        Vector3 moveDirection = Quaternion.Euler(0f, lookDirection, 0f) * Vector3.forward;
        controller._rb.AddForce(moveDirection * _moveSpeed * _moveForceMultiplier);

    }

    public void Run()
    {
        // return _isSprinting = context.performed ? true : false;
        Debug.Log("Sprint");
        _isSprinting = true;
        _moveSpeed = _moveSpeed + _moveSpeedBoost;
        Debug.Log("Current Speed pressed: " + _moveSpeed);
    }

    public void RunCanceled()
    {
        Debug.Log("Canceled");
        _isSprinting = false;
        _moveSpeed = _defaultMoveSpeed;
        Debug.Log("Current Speed not pressed: " + _moveSpeed);
    }
}
