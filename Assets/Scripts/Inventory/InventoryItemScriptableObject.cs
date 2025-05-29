
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemConfig", menuName = "Inventory/ListInventoryItem")]
public class InventoryItemScriptableObject : ScriptableObject
{
    public List<InventoryItem> LsInventoryItem;
}

[Serializable]
public class InventoryItem
{
    public string id;
    public string itemName;
    public int value;
    public Sprite image;
    public Sprite icon;

    public InventoryItem(InventoryItem item)
    {
        this.id = item.id;
        this.itemName = item.itemName;
        this.value = item.value;
        this.image = item.image;
        this.icon = item.icon;
    }
    public InventoryItem()
    {
    }
    public InventoryItem(string id, string name)
    {

    }
    ~InventoryItem()
    {
    }

}
