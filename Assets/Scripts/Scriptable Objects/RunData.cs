using UnityEngine;

[CreateAssetMenu(menuName = "Systems/Movement/Mechanics/Run")]
public class RunData : ScriptableObject
{
    public MovementSystem movementSystem;

    public bool isSprinting;
    public bool sprint;

    public float defaultMoveSpeed;
    public float moveSpeedBoost;

    private void Awake()
    {
        defaultMoveSpeed = movementSystem.walk.moveSpeed;
    }
}