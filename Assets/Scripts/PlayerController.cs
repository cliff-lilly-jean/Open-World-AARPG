using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 _inputVector;
    private Vector3 _direction;
    private Rigidbody _rb;

    [SerializeField] private float _speed;
    [SerializeField] private float _smoothTime = 0.05f;
    [SerializeField] private float _jumpStrength;
    [SerializeField] private float _gravityMultiplier = 3.0f;

    private float _currentVelocity;
    private float _groundCheck;
    private float _bufferDistance = 0.01f;
    private float _gravity = -9.81f;
    private float _velocity;
    private bool _isGrounded = true;

    public Transform cam;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        if (_inputVector.sqrMagnitude == 0) return;
        ApplyMovement();

    }

    public void Move(InputAction.CallbackContext context)
    {
        // Get input
        _inputVector = context.ReadValue<Vector2>();

        // Convert input variables
        _direction = _inputVector;

    }

    public void ApplyMovement()
    {
        // Get direction angles
        var lookDirection = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, lookDirection, ref _currentVelocity, _smoothTime);

        // Rotate the transform in the lookDirection
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        // Move the player in the direction of the rotation
        Vector3 moveDirection = Quaternion.Euler(0f, lookDirection, 0f) * Vector3.forward;
        _rb.AddForce(moveDirection.normalized * _speed);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        GroundCheck();
        if (_isGrounded)
        {
            AddJumpForce();
        }
    }


    public void GroundCheck()
    {
        // Create a capsule buffer
        _groundCheck = (GetComponent<CapsuleCollider>().height / 2) + _bufferDistance;

        //Perform a raycast down
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, _groundCheck))
        {
            // If grounded, Run the jump action
            _isGrounded = true;
        }
        else
        {
            // ray didn't hit ground
            _isGrounded = false;

        }
    }

    public void AddJumpForce()
    {
        _rb.AddForce(transform.up * _jumpStrength, ForceMode.Impulse);
    }


}
