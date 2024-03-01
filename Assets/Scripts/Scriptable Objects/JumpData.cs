using UnityEngine;

[CreateAssetMenu(menuName = "Systems/Movement/Mechanics/Jump")]
public class JumpData : ScriptableObject
{
    public bool isGrounded;
    public bool isJumping;

    public float groundDistance;
    public float jumpStrength;
    public float gravityForceMultiplier = 6f;
}
