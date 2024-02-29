using UnityEngine;

[CreateAssetMenu(menuName = "Systems/Movement/Movement System")]
public class MovementSystem : ScriptableObject
{

    public WalkData walk;
    public JumpData jump;
    public StaminaData stamina;

    public float force = 100;

    // Use OnEnable to initialize Image, Transforms, GameObjects
    private void Awake()
    {

    }
}
