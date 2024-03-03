using UnityEngine;

public class Run : MonoBehaviour
{
    public MovementSystem movementSystem;
    PlayerController controller;


    void Start()
    {
        controller = GetComponent<PlayerController>();
    }


    public void Activate()
    {
        movementSystem.sprint.isRunning = true;

        if (movementSystem.sprint.isRunning && movementSystem.endurance._stamina > 0)
        {
            movementSystem.walk.moveSpeed += movementSystem.sprint.moveSpeedBoost;

            Debug.Log(movementSystem.walk.moveSpeed);
        }
        else
        {
            Cancel();
        }
    }

    public void Cancel()
    {
        movementSystem.sprint.isRunning = false;
        movementSystem.walk.moveSpeed += movementSystem.sprint.defaultMoveSpeed;

        Debug.Log(movementSystem.walk.moveSpeed);
    }
}