using UnityEditor.Rendering;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public PlayerController controller;
    public MovementSystem movementSystem;
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
        // Move
        if (movementSystem.walk.moveDirection.sqrMagnitude == 0) { };
        Activate();
    }

    public void Activate()
    {

        // Get input
        movementSystem.walk.moveDirection = controller.controls.Gameplay.Walk.ReadValue<Vector2>();

        // Get direction angles
        var lookDirection = Mathf.Atan2(movementSystem.walk.moveDirection.x, movementSystem.walk.moveDirection.y) * Mathf.Rad2Deg + lookCamera.eulerAngles.y;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, lookDirection, ref movementSystem.walk.currentMoveVelocity, movementSystem.walk.lookDirectionSmoothTime);

        // Rotate the transform in the lookDirection
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        // Move the player in the direction of the rotation
        Vector3 moveDirection = Quaternion.Euler(0f, lookDirection, 0f) * Vector3.forward;
        controller._rb.AddForce(moveDirection * movementSystem.walk.moveSpeed * movementSystem.force);

    }


}
