using UnityEngine;

public class Jump : MonoBehaviour
{
    public PlayerController controller;

    private bool _isGrounded;
    private bool _isJumping;

    private float _groundCheck;

    [SerializeField] private float _jumpForceMultiplier = 100;
    [SerializeField] private float _jumpStrength;
    [SerializeField] private float _gravityForceMultiplyer = 6f;
    [SerializeField] private float _bufferDistance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();

        // Gravity
        if (!_isGrounded && !_isJumping)
        {
            if (controller._rb.velocity.y < 0.1)
            {
                Debug.Log("Down");
                ApplyGravity();
            }
        }
    }

    private void ApplyGravity()
    {
        controller._rb.AddForce(Vector3.down * _gravityForceMultiplyer * Time.deltaTime, ForceMode.VelocityChange);
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

    public void ApplyForce()
    {

        controller._rb.AddForce(Vector3.up * _jumpStrength * _jumpForceMultiplier, ForceMode.Impulse);

    }
}


