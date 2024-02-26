using UnityEngine;

[CreateAssetMenu(menuName = "Systems/Stamina")]
public class StaminaSO : ScriptableObject
{
    public MovementSystemSO movementSystem;

    public float _stamina;
    public float _maxStamina = 100f;
    public float _wheelFillSpeedOffset;
}