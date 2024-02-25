using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Systems/Movement/Mechanics/Move")]
public class MoveSO : ScriptableObject
{
    public Vector2 moveDirection;

    public float lookDirectionSmoothTime = 0.05f;
    public float moveSpeed;
    public float defaultMoveSpeed;
    public float moveSpeedBoost;
    public float currentMoveVelocity;

    public bool isSprinting;
    public bool sprint;

    private void OnEnable()
    {
        defaultMoveSpeed = moveSpeed;
    }
}
