using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Systems/Movement/Movement System")]
public class MovementSystemSO : ScriptableObject
{
    public GameControls controls;
    public Rigidbody _rb;

    public MoveSO move;
    public JumpSO jump;

    public float force = 100;

    // Use OnEnable to initialize Image, Transforms, Gameobjects
}
