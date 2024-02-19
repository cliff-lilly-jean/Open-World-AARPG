using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Vector2 _direction;
    private Vector3 _gravityFOrce;
    private Rigidbody _rb;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpStrength;
    [SerializeField] public float _gravity = -20f;
    [SerializeField] private float _playerRotationSmoothTime = 0.05f;

    private float _currentVelocity;
    private float _groundCheck;

    private float _bufferDistance = 0.1f;

    private bool _isGrounded;
    private bool _jump;


    public Transform cameraTransform;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude == 0) return;
        ApplyMovement();



        // if (!IsGrounded() && _rb.velocity.y >= 1.5f)
        // {
        //     ApplyGravity();
        // }
    }

    #region Move
    public void Move(InputAction.CallbackContext context)
    {
        // Get input
        _direction = context.ReadValue<Vector2>();

    }

    private void ApplyMovement()
    {
        // Get direction angles
        var lookDirection = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, lookDirection, ref _currentVelocity, _playerRotationSmoothTime);

        // Rotate the transform in the lookDirection
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        // Move the player in the direction of the rotation
        Vector3 moveDirection = Quaternion.Euler(0f, lookDirection, 0f) * Vector3.forward;
        _rb.AddForce(moveDirection.normalized * _speed);
    }

    #endregion Move

    #region Jump

    public void Jump(InputAction.CallbackContext context)
    {
        _jump = context.performed;
        Debug.Log(_jump);
        if (_jump && IsGrounded())
        {
            ApplyJump();
        }

    }

    public void ApplyJump()
    {
        Debug.Log("Jump pressed");
        _rb.AddForce(Vector3.up * _jumpStrength, ForceMode.Force);
    }

    private bool IsGrounded()
    {
        // Create a capsule buffer from the ground
        _groundCheck = (GetComponent<CapsuleCollider>().height / 2) + _bufferDistance;

        //Perform a raycast down
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, _groundCheck))
        {
            // If grounded, Run the jump action
            return _isGrounded = true;
        }
        else
        {
            // Don't allow Jump action
            return _isGrounded = false;
        }
    }

    private void ApplyGravity()
    {
        Debug.Log("Gravity applied");
        _rb.AddForce(Vector3.down, ForceMode.Force);
    }
    #endregion Jump
}



