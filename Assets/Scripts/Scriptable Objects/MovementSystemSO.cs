using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Systems/Movement/Movement System")]
public class MovementSystemSO : ScriptableObject
{
    public GameControls controls;

    public MoveSO move;
    public JumpSO jump;

    public float force = 100;

    private void Awake()
    {

    }
}
