using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public GameControls controls;
    public Rigidbody _rb;
    MovementSystem movementSystem;

    public Move move;
    public Run run;
    public Stamina stamina;
    public Jump jump;


    private void Awake()
    {
        // Input System Controls
        controls = new GameControls();

        // Rigidbody
        _rb = GetComponent<Rigidbody>();

        // Controllers
        move = GetComponent<Move>();
        run = GetComponent<Run>();
        jump = GetComponent<Jump>();
        stamina = GetComponent<Stamina>();

        // Controls
        controls.Gameplay.Walk.performed += ctx => move.Activate();

        controls.Gameplay.Jump.performed += ctx => jump.Activate(ctx);

        controls.Gameplay.Run.performed += ctx => run.Activate();
        controls.Gameplay.Run.canceled += ctx => run.Cancel();
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        // if (movementSystem.walk.moveDirection.sqrMagnitude == 0) { };
        // move.Activate();
    }

    public void OnEnable()
    {
        controls.Enable();
    }

    public void OnDisable()
    {
        controls.Disable();
    }
}



