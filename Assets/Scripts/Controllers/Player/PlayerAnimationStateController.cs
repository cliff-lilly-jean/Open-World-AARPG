using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationStateController : MonoBehaviour
{
    public PlayerController controller;
    public MovementSystem movementSystem;
    Animator animator;

    private bool _isWalking;
    float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;


    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();


    }

    // Start is called before the first frame update
    void Start()
    {
        // * note: Run a method when the walk method is run that toggles the animator true or false
        controller.controls.Gameplay.Walk.performed += ctx => IsWalking(ctx);
        controller.controls.Gameplay.Walk.canceled += ctx => IsWalking(ctx);

        controller.controls.Gameplay.Run.performed += ctx => IsRunning(ctx);
        controller.controls.Gameplay.Run.canceled += ctx => IsRunning(ctx);

    }

    // Update is called once per frame
    void Update()
    {
        // Walk
        ActivateWalk();
    }

    public void ActivateWalk()
    {
        if (_isWalking && velocity < 1.0f)
        {
            velocity += Time.deltaTime * acceleration;
        }

        if (!_isWalking && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deceleration;
        }

        if (!_isWalking && velocity < 0.0f)
        {
            velocity = 0.0f;
        }

        // animator.SetFloat("Velocity", velocity);
    }


    public void IsWalking(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _isWalking = true;
        }

        if (context.canceled && velocity > 0.0f)
        {
            _isWalking = false;
        }

        if (context.canceled && velocity < 0.0f)
        {
            _isWalking = false;
        }
    }

    // Run
    public void IsRunning(InputAction.CallbackContext context)
    {
        if (context.performed && _isWalking)
        {
            animator.SetBool("isRunning", true);
            movementSystem.run.isRunning = true;

            if (movementSystem.run.isRunning && movementSystem.stamina._stamina > 0)
            {
                movementSystem.walk.moveSpeed = movementSystem.walk.moveSpeed + movementSystem.run.moveSpeedBoost;
            }
        }

        if (context.canceled || !_isWalking)
        {
            animator.SetBool("isRunning", false);

            movementSystem.run.isRunning = false;
            movementSystem.walk.moveSpeed = movementSystem.run.defaultMoveSpeed;
        }
    }
}
