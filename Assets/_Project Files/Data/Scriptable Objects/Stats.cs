using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "Open World AARPG/Stats")]
public class Stats : ScriptableObject
{
    [Header("General")]
    string name;

    [Header("Physical")]
    float speed;
    float attack;
    float defense;

    [Header("Vitals")]
    float health;
    float stamina;
    float aura; // ki, mana, spirit, soul power, nen
}