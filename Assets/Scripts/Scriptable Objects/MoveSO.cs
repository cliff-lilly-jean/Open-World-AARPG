using UnityEngine;

public class MoveSO : MonoBehaviour
{
    public Vector2 moveDirection;
    public PlayerController controller;
    public Transform lookCamera;

    public float lookDirectionSmoothTime = 0.05f;
    public float moveSpeed;
    public float moveSpeedBoost;
    public float defaultMoveSpeed;
    public float currentMoveVelocity;

    public bool isSprinting;
    public bool sprint;

    private void Awake()
    {
        defaultMoveSpeed = moveSpeed;
    }
}
