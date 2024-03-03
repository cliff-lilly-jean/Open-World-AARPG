using UnityEngine;

[CreateAssetMenu(menuName = "Systems/MovementSystem/Mechanics/Jump")]
public class Leap : ScriptableObject
{
    public bool isGrounded;
    public bool isJumping;

    public float groundDistance;
    public float jumpStrength;
    public float gravityForceMultiplier = 6f;
}
