using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public GameControls controls;
    public Rigidbody _rb;



    private void Awake()
    {
        // Input System Controls
        controls = new GameControls();

        // Rigidbody
        _rb = GetComponent<Rigidbody>();

    }

    private void Start()
    {

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



