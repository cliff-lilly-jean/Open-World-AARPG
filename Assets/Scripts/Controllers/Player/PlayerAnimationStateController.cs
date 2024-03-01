using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationStateController : MonoBehaviour
{
    PlayerController controller;
    Animator animator;

    private bool _isWalking;


    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();

        // * note: Run a method when the walk method is run that toggles the animator true or false
        controller.controls.Gameplay.Walk.performed += ctx => IsWalking(ctx);
        controller.controls.Gameplay.Walk.canceled += ctx => IsWalking(ctx);

        controller.controls.Gameplay.Run.performed += ctx => IsRunning(ctx);
        controller.controls.Gameplay.Run.canceled += ctx => IsRunning(ctx);
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
            Debug.Log("True");
            animator.SetBool("isWalking", true);
        }

        if (context.canceled)
        {
            Debug.Log("False");
            animator.SetBool("isWalking", false);
        }
    }

    // Run
    public void IsRunning(InputAction.CallbackContext context)
    {
        if (context.performed && _isWalking)
        {
            Debug.Log("True");
            animator.SetBool("isRunning", true);
        }

        if (context.canceled || !_isWalking)
        {
            Debug.Log("False");
            animator.SetBool("isRunning", false);
        }
    }
}
