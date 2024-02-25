using UnityEngine;

[CreateAssetMenu(menuName = "Systems/Movement")]
public class MovementSystemSO : ScriptableObject
{
    // Jump
    public bool isGrounded;
    public bool isJumping;

    public float groundCheck;
    public float jumpStrength;
    public float gravityForceMultiplyer = 6f;
    public float bufferDistance = 0.1f;

    // Move
    public Vector2 moveDirection;
    public PlayerController controller;

    public float lookDirectionSmoothTime = 0.05f;
    public float moveSpeed;
    public float moveSpeedBoost;
    public float defaultMoveSpeed;
    public float currentMoveVelocity;

    public bool isSprinting;
    public bool sprint;

    // Shared
    public float force = 100;
}
