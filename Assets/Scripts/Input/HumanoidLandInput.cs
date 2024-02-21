using UnityEngine;
using UnityEngine.InputSystem;

public class HumanoidLandInput : MonoBehaviour
{

    public Vector2 moveInput { get; private set; } = Vector2.zero;
    public Vector2 lookInput { get; private set; } = Vector2.zero;
    public bool moveIsPressed = false;

    Controls _controls = null;

    private void OnEnable()
    {
        _controls = new Controls();
        _controls.HumanoidLand.Enable();

        // Move
        _controls.HumanoidLand.Move.performed += SetMove;
        _controls.HumanoidLand.Move.canceled += SetMove;

        _controls.HumanoidLand.Look.performed += SetLook;
        _controls.HumanoidLand.Look.canceled += SetLook;
    }

    private void OnDisable()
    {
        // Move
        _controls.HumanoidLand.Move.performed -= SetMove;
        _controls.HumanoidLand.Move.canceled -= SetMove;

        // Look
        _controls.HumanoidLand.Look.performed -= SetLook;
        _controls.HumanoidLand.Look.canceled -= SetLook;

        _controls.HumanoidLand.Disable();
    }

    private void SetMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        moveIsPressed = !(moveInput == Vector2.zero);
    }

    private void SetLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}
