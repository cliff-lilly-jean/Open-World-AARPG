using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public GameControls controls;
    public Rigidbody _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        Jump jump = GetComponent<Jump>();
        Walk walk = GetComponent<Walk>();

        controls = new GameControls();

        // Jump
        controls.Gameplay.Jump.performed += _ => jump.Activate();

        // Move
        controls.Gameplay.Move.performed += _ => walk.Activate();

        // Run
        controls.Gameplay.Run.performed += _ => move.Run();
        controls.Gameplay.Run.canceled += _ => move.RunCanceled();
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



