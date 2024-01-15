using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item/New Item")]
public class ItemSO : ScriptableObject
{
    public string name;
    public float durability;


    public GameObject prefab;
    public ItemTypeSO itemType; // Scriptable Object of types of items, ex. Weapon, Armor(Clothes), Shield, Consumeable, Material
    public ElementSO element; // Scriptable Object of element of the Item, ex. Fire, Wind/Air, Water, Earth, Electricity
}