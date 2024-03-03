using UnityEngine;

[CreateAssetMenu(menuName = "Systems/MovementSystem/MovementSystem System")]
public class MovementSystem : ScriptableObject
{

    public Walk walk;
    public Leap leap;
    public Sprint sprint;
    public Endurance endurance;

    public float force = 100;

    // Use OnEnable to initialize Image, Transforms, GameObjects

}
