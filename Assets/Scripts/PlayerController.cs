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
    [SerializeField] private float _bodyMass;

    private float _currentVelocity;
    private float _groundCheck;
    private float _bufferDistance = 0.01f;
    private bool _isGrounded = true;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        if (_inputVector.sqrMagnitude == 0) return;
        Walk();
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Get input
        _inputVector = context.ReadValue<Vector2>();

        // Convert input variables
        _direction.x = _inputVector.x;
        _direction.y = _inputVector.y;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        GroundCheck();
    }


    public void Walk()
    {
        LookRotation();
        WalkSpeed();
    }

    public void LookRotation()
    {
        // Get direction angles
        var lookDirection = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg;
        var rotationAngle = RotationSmoothing(lookDirection);

        // Rotate the transform in the lookDirection
        transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
    }

    public float RotationSmoothing(float direction)
    {
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, direction, ref _currentVelocity, _smoothTime);
        return angle;
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
            AddJumpForce();
        }
        else
        {
            // ray didn't hit ground
            _isGrounded = false;
        }
    }

    public void WalkSpeed()
    {
        Vector3 movement = new Vector3(_direction.x, 0f, _direction.y);
        _rb.AddForce(movement * _speed);
    }

    public void AddJumpForce()
    {
        _rb.AddForce(transform.up * _jumpStrength, ForceMode.Impulse);
        /*
            ***Less Floaty Jump***
            - Determine if player is in the air

            - Add gravity/mass to player
            - Determine if player is on the ground
            - reset gravity/mass
        */
    }
}
