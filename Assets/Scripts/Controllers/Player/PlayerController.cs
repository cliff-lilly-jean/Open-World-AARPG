using UnityEngine;

// [RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public GameControls controls;
    public Rigidbody _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        Jump jump = GetComponent<Jump>();
        Walk walk = GetComponent<Walk>();
        Run run = GetComponent<Run>();

        controls = new GameControls();

        // Jump
        controls.Gameplay.Jump.performed += _ => jump.Activate();

        // Move
        controls.Gameplay.Walk.performed += _ => walk.Activate();

        // Run
        controls.Gameplay.Run.performed += _ => run.Activate();
        controls.Gameplay.Run.canceled += _ => run.Cancel();
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



