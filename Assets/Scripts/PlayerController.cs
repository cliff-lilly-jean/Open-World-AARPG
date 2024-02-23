using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    GameControls controls;
    bool _sprint;

    private Vector2 _direction;
    private Rigidbody _rb;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpStrength;
    [SerializeField] private float _smoothTime = 0.05f;
    [SerializeField] private float _gravityForce = 6f;
    [SerializeField] private float _speedBoost;

    private float _currentVelocity;
    private float _groundCheck;
    private float _defaultSpeed;
    private float _force = 100;

    private float _bufferDistance = 0.1f;

    private bool _isGrounded;
    private bool _isJumping;
    private bool _isSprinting;


    public Transform cam;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _defaultSpeed = _speed;

        controls = new GameControls();

        // Jump
        controls.Gameplay.Jump.performed += _ => Jump();

        // Move
        controls.Gameplay.Move.performed += _ => Move();

        // Sprint
        controls.Gameplay.Sprint.performed += _ => Sprint();
        controls.Gameplay.Sprint.canceled += _ => SprintCanceled();
    }

    private void Update()
    {
        // Ground check
        GroundCheck();

        // Gravity
        if (!_isGrounded && !_isJumping)
        {
            if (_rb.velocity.y < 0.1)
            {
                Debug.Log("Down");
                ApplyGravity();
            }
        }

    }

    private void FixedUpdate()
    {
        // Move
        if (_direction.sqrMagnitude == 0) return;
        Move();
    }

    #region Move
    public void Move()
    {

        // Get input
        _direction = controls.Gameplay.Move.ReadValue<Vector2>();

        // Get direction angles
        var lookDirection = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, lookDirection, ref _currentVelocity, _smoothTime);

        // Rotate the transform in the lookDirection
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        // Move the player in the direction of the rotation
        Vector3 moveDirection = Quaternion.Euler(0f, lookDirection, 0f) * Vector3.forward;
        _rb.AddForce(moveDirection * _speed * _force);

    }

    #endregion Move

    #region Jump

    private void Jump()
    {

        _rb.AddForce(Vector3.up * _jumpStrength * _force, ForceMode.Impulse);

    }

    private void GroundCheck()
    {
        // Create a capsule buffer from the ground
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
            // Don't allow Jump action
            _isGrounded = false;
        }
    }

    private void ApplyGravity()
    {
        _rb.AddForce(Vector3.down * _gravityForce * Time.deltaTime, ForceMode.VelocityChange);
    }
    #endregion Jump

    #region Sprint
    private void Sprint()
    {
        // return _isSprinting = context.performed ? true : false;
        Debug.Log("Sprint");
        _isSprinting = true;
        _speed = _speed + _speedBoost;
        Debug.Log("Current Speed pressed: " + _speed);
    }

    private void SprintCanceled()
    {
        Debug.Log("Canceled");
        _isSprinting = false;
        _speed = _defaultSpeed;
        Debug.Log("Current Speed not pressed: " + _speed);
    }

    #endregion

    public void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    public void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}



