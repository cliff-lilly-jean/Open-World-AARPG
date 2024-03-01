using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationStateController : MonoBehaviour
{
    PlayerController controller;
    MovementSystem movementSystem;
    Animator animator;

    private bool _isWalking;


    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();

        // * note: Run a method when the walk method is run that toggles the animator true or false
        controller.controls.Gameplay.Walk.performed += ctx => IsWalking(ctx);
        controller.controls.Gameplay.Walk.canceled += ctx => IsWalking(ctx);

        controller.controls.Gameplay.Run.performed += ctx => isSprinting(ctx);
        controller.controls.Gameplay.Run.canceled += ctx => isSprinting(ctx);
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        _isWalking = animator.GetBool("isWalking");
    }

    // Walk
    public void IsWalking(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetBool("isWalking", true);
        }

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
        }
    }

    // Run
    public void isSprinting(InputAction.CallbackContext context)
    {
        if (context.performed && _isWalking)
        {
            animator.SetBool("isSprinting", true);
        }

        if (context.canceled || !_isWalking)
        {
            animator.SetBool("isSprinting", false);
            // movementSystem.run.isSprinting = false;
        }
    }
}
