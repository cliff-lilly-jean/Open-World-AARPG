using UnityEngine;

[CreateAssetMenu(menuName = "Systems/Movement/Mechanics/Jump")]
public class JumpSO : ScriptableObject
{
    public bool isGrounded;
    public bool isJumping;

    public float groundCheck;
    public float jumpStrength;
    public float gravityForceMultiplier = 6f;
    public float bufferDistance = 0.1f;

    public int numberOfJumpsLeft;
    public int maxNumberOfJumps = 1;

    private void Awake()
    {
        numberOfJumpsLeft = maxNumberOfJumps;
    }
}
