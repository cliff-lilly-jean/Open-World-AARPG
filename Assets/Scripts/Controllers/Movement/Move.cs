using UnityEditor.Rendering;
using UnityEngine;

public class Move : MonoBehaviour
{
    PlayerController controller;
    public MovementSystem MovementSystem;
    public Transform lookCamera;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (MovementSystem.walk.moveDirection.sqrMagnitude == 0) { };
        Activate();
    }

    public void Activate()
    {

        // Get input
        MovementSystem.walk.moveDirection = controller.controls.Gameplay.Walk.ReadValue<Vector2>();

        // Get direction angles
        var lookDirection = Mathf.Atan2(MovementSystem.walk.moveDirection.x, MovementSystem.walk.moveDirection.y) * Mathf.Rad2Deg + lookCamera.eulerAngles.y;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, lookDirection, ref MovementSystem.walk.currentMoveVelocity, MovementSystem.walk.lookDirectionSmoothTime);

        // Rotate the transform in the lookDirection
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        // Move the player in the direction of the rotation
        Vector3 moveDirection = Quaternion.Euler(0f, lookDirection, 0f) * Vector3.forward;
        controller._rb.AddForce(moveDirection * MovementSystem.walk.moveSpeed * MovementSystem.force);
    }


}
