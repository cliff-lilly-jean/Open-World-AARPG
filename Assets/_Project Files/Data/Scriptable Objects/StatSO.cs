using UnityEngine;


[CreateAssetMenu(fileName = "Stat", menuName = "Stats/Stat")]
public class StatSO : ScriptableObject
{
    [Header("Physical")]
    public float speed = 1f; // ability to evade attacks; 1pt = +4 speed
    public float attack = 1f; // 1pt = +1 attack; EQUATION: attack + weapon + weapon buff(elemental or other) - defense + armor
    public float defense = 1f; // 1pt = +1 defense

    [Header("Vitals")]
    public float health = 4f; // 1pt = 1/4th of a heart; 4pt = 1 heart;
    public float stamina = 10f; // 1pt = 1/10th of stamina wheel; 10pt = 1 section; how long you can perform certain physical actions; decreases as used; quickly refills
    public float lespri = 10f; // 1pt = 1/10th of lespri bar; 10pt = 1 section; how long/how large you can shoot blasts; decreases as used; slowly refills
}