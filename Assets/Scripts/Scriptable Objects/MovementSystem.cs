using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Systems/Movement/Movement System")]
public class MovementSystem : ScriptableObject
{

    public Move move;
    public Jump jump;
    public Stamina stamina;

    public float force = 100;

    // Use OnEnable to initialize Image, Transforms, GameObjects

}
