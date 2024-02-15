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
    private float _bufferDistance = 0.1f;
    private float _gravityScale = 5;
    private float _fallGravityScale = 20;
    private float _velocity;
    private bool _isGrounded;

    public Transform cam;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GroundCheck();
    }

    private void FixedUpdate()
    {

        if (_inputVector.sqrMagnitude == 0) return;

        // Move
        ApplyMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Get input
        _inputVector = context.ReadValue<Vector2>();

        // Convert input variables
        _direction = _inputVector;

    }

    private void ApplyMovement()
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

    private void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        // If the player is on the ground:
        // -- Reset player gravity or weight
        // -- Move the player vertically
        // ---- If the player velocity is greater than 70% of jump height
        // ------ Add some weight or gravity to the player


        if (_isGrounded)
        {
            ApplyJumpForce();
            // ApplyGravity();
        }
    }


    private bool GroundCheck()
    {
        // Create a capsule buffer
        _groundCheck = (GetComponent<CapsuleCollider>().height / 2) + _bufferDistance;

        //Perform a raycast down
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.up, out hit, _groundCheck))
        {
            // If grounded, Run the jump action
            Debug.Log("On ground");
            return _isGrounded = true;
        }
        else
        {
            // Don't allow Jump action
            Debug.Log("In air");
            return _isGrounded = false;
        }
    }

    private void ApplyJumpForce()
    {
        _rb.AddForce(Vector3.up * _jumpStrength, ForceMode.Impulse);
    }
}
