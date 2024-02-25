using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Systems/Movement")]
public class MovementSystemSO : ScriptableObject
{
    public GameControls controls;

    public MoveSO move;
    public JumpSO jump;

    public float force = 100;
}
