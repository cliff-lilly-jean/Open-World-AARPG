using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Vector2 _inputVector;
    private Vector3 _direction;
    private Vector3 _velocity;
    private Rigidbody _rb;

    [SerializeField] private float _speed;
    [SerializeField] private float _smoothTime = 0.05f;
    [SerializeField] private float _jumpStrength;

    private float _currentVelocity;
    private float _groundCheck;
    private float _bufferDistance = 0.1f;

    private bool _isGrounded;
    private bool _jumpStarted;


    public Transform cam;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _velocity = _rb.velocity;
    }

    private void Update()
    {
        IsGrounded();
    }

    private void FixedUpdate()
    {


        if (_inputVector.sqrMagnitude == 0) return;

        // Move
        ApplyMovement();
        var jump += => _ Jum;



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

        // if (!context.started) return;
        Debug.Log(context);
        Debug.Log(_rb.transform.position.y);
        if (IsGrounded())
        {
            ApplyJumpForce();
        }

        // if (_rb.transform.position.y >= 3f && !IsGrounded())
        // {

        //     ApplyDownForce();
        // }
    }


    private bool IsGrounded()
    {
        // Create a capsule buffer from the ground
        _groundCheck = (GetComponent<CapsuleCollider>().height / 2) + _bufferDistance;

        //Perform a raycast down
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.up, out hit, _groundCheck))
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

    private void ApplyJumpForce()
    {
        _rb.AddForce(Vector3.up * _jumpStrength, ForceMode.Impulse);

    }

    private void ApplyDownForce()
    {
        _rb.AddForce(Vector3.down * 6.4f, ForceMode.Impulse);
        Debug.Log("Downforce applied");

        if (_rb.transform.position.y <= 0.1f)
        {
            _isGrounded = true;
            Debug.Log("Grounded");
        }
    }
}
