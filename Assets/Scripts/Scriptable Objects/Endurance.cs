using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Systems/MovementSystem/Mechanics/Endurance")]
public class Endurance : ScriptableObject
{

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
