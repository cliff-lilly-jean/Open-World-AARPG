using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Systems/MovementSystem/Mechanics/Walk")]
public class Walk : ScriptableObject
{
    public Vector2 moveDirection;

    public float lookDirectionSmoothTime = 0.05f;
    public float moveSpeed;

    public float currentMoveVelocity;

    public bool isWalking;
}
