using UnityEngine;

[CreateAssetMenu(menuName = "Systems/MovementSystem/Mechanics/Run")]
public class Sprint : ScriptableObject
{
    public MovementSystem movementSystem;

    public bool isRunning;
    public bool sprint;

    public float defaultMoveSpeed;
    public float moveSpeedBoost;

    private void Awake()
    {
        defaultMoveSpeed = movementSystem.walk.moveSpeed;
    }
}