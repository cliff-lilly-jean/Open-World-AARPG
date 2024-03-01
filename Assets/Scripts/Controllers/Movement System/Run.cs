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
        movementSystem.run.isSprinting = true;

        if (movementSystem.run.isSprinting && movementSystem.stamina._stamina > 0)
        {
            movementSystem.walk.moveSpeed += movementSystem.run.moveSpeedBoost;
        }
        else
        {
            if (movementSystem.stamina._stamina <= 0)
            {
                Cancel();
            }
        }
    }

    public void Cancel()
    {
        movementSystem.run.isSprinting = false;
        movementSystem.walk.moveSpeed = movementSystem.run.defaultMoveSpeed;
    }
}