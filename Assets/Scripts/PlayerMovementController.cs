using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour
{

    private float moveSpeed = 1f;
    private float jumpForce = 3f;
    private float _remainingJumps = 1;

    GameControls actions;

    private Rigidbody _playerRigidBody;
    private Vector2 _moveVector;


    // Start is called before the first frame update
    void Awake()
    {
        actions = new GameControls();
        actions.Gameplay.Jump.performed += _ => OnJump();
        _moveVector = actions.Gameplay.Move.ReadValue<Vector2>();

        _playerRigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OnMove();
    }

    private void OnEnable()
    {
        actions.Gameplay.Enable(); ;
    }

    private void OnDisable()
    {
        actions.Gameplay.Disable();
    }


    #region Methods
    public void OnJump()
    {

        _playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

    private void OnMove()
    {

        _moveVector = actions.Gameplay.Move.ReadValue<Vector2>();
        // _playerRigidBody.AddForce(new Vector3(_moveVector.x, 0, _moveVector.y) * moveSpeed, ForceMode.Impulse);
        // Debug.Log(_moveVector.y);
        CameraRelativeMovement(_moveVector);

    }

    private void CameraRelativeMovement(Vector2 moveVector)
    {
        // Get Camera's directional vectors
        Vector3 _cameraForward = transform.InverseTransformVector(Camera.main.transform.forward);
        Vector3 _cameraRight = transform.InverseTransformVector(Camera.main.transform.right);

        // Normalize Camera's directional vectors
        _cameraForward.y = 0;
        _cameraRight.x = 0;
        _cameraForward = _cameraForward.normalized;
        _cameraRight = _cameraRight.normalized;

        // Create Direction relative Input Vectors
        Vector3 _forwardRelativeVerticalInput = moveVector.y * _cameraForward;
        Vector3 _rightRelativeHorizontalInput = moveVector.x * _cameraRight;

        // Create Camera relative movement
        Vector3 _cameraRelativeMovement = _forwardRelativeVerticalInput + _rightRelativeHorizontalInput;

        // transform.Translate(_cameraRelativeMovement);
        _playerRigidBody.AddForce(new Vector3(_cameraRelativeMovement.x, 0, _cameraRelativeMovement.z) * moveSpeed, ForceMode.Impulse);
    }

    #endregion
}
