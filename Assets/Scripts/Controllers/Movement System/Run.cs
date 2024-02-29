using UnityEngine;

public class Run : MonoBehaviour
{
    public MovementSystem movementSystem;



    public void Activate()
    {
        movementSystem.move.isSprinting = true;

        if (movementSystem.move.isSprinting && movementSystem.stamina._stamina > 0)
        {
            movementSystem.move.moveSpeed += movementSystem.move.moveSpeedBoost;
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
        movementSystem.move.isSprinting = false;
        movementSystem.move.moveSpeed = movementSystem.move.defaultMoveSpeed;
    }
}