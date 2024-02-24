using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Jump jump;
    Move move;

    public GameControls controls;
    public Rigidbody _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        jump = GetComponent<Jump>();
        move = GetComponent<Move>();

        controls = new GameControls();

        // Jump
        controls.Gameplay.Jump.performed += _ => jump.ApplyForce();

        // Move
        controls.Gameplay.Move.performed += _ => move.Walk();

        // Run
        controls.Gameplay.Run.performed += _ => move.Run();
        controls.Gameplay.Run.canceled += _ => move.RunCanceled();
    }

    public void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    public void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}



