using UnityEngine;

[CreateAssetMenu(fileName = "Item Type", menuName = "Items/Item/New Item Type")]
public class ItemTypeSO : ScriptableObject
{
    public string itemCategory; // Weapon, Material, Shield
    public string itemDescription;
}