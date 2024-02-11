using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    private Vector2 _inputVector;
    private Rigidbody _rb;

    private float _movementX;
    private float _movementY;

    public float _speed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_movementX, 0f, _movementY);
        _rb.AddForce(movement * _speed);
        Debug.Log(movement);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _inputVector = context.ReadValue<Vector2>();

        _movementX = _inputVector.x;
        _movementY = _inputVector.y;
        // Debug.Log(_inputVector);
    }
}
