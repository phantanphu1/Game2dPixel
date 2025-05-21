
using UnityEngine;

[CreateAssetMenu(fileName = "New item List", menuName = "Inventory/item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int valueHp;
    public Sprite image;
}
