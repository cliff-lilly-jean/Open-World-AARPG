using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    private Vector2 _inputVector;
    private Rigidbody _rb;
    private Vector3 _direction;


    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _smoothTime = 0.05f;

    private float _currentVelocity;

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


    public void Walk()
    {
        LookRotation();
        Vector3 movement = new Vector3(_direction.x, 0f, _direction.y);
        _rb.AddForce(movement * _speed);
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
}
