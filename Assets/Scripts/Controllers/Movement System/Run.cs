using UnityEngine;

public class Run : MonoBehaviour
{
    public MovementSystem movementSystem;


    public void Activate()
    {
        movementSystem.run.isSprinting = true;

        if (movementSystem.run.isSprinting && movementSystem.stamina._stamina > 0)
        {
            movementSystem.walk.moveSpeed += movementSystem.run.moveSpeedBoost;
            Debug.Log("Move" + movementSystem.stamina._stamina);

        }
        else
        {
            if (movementSystem.stamina._stamina <= 0)
            {
                Cancel();
                Debug.Log("Regaining stamina");
            }
        }
    }

    public void Cancel()
    {
        movementSystem.run.isSprinting = false;
        movementSystem.walk.moveSpeed = movementSystem.run.defaultMoveSpeed;
    }
}