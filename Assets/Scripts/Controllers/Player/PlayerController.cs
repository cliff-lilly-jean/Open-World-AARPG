using UnityEngine;

// [RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public GameControls controls;
    public Rigidbody _rb;



    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        controls = new GameControls();
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



