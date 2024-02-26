using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Systems/Movement/Movement System")]
public class MovementSystemSO : ScriptableObject
{

    public MoveSO move;
    public JumpSO jump;
    public StaminaSO stamina;

    public float force = 100;

    // Use OnEnable to initialize Image, Transforms, GameObjects

}
