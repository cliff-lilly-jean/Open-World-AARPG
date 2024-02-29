using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Systems/Movement/Stamina")]
public class StaminaData : ScriptableObject
{
    public MovementSystem movementSystem;

    public float _stamina;
    public float _maxStamina = 100f;

    public bool _staminaExhausted;

    // Stamina Wheel
    public float _wheelFillSpeedOffset;

    private void OnEnable()
    {
        _stamina = _maxStamina;
    }
}
