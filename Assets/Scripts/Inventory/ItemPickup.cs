using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // public InventoryItemScriptableObject item;
    public InventoryItem item1;
    public void Pickup()
    {
        this.gameObject.SetActive(false);
        // thêm vật phẩm vào kho đồ
        var newItem = CopyItem(item1);
        newItem.value = UnityEngine.Random.Range(5, 20);
        InventoryManager.Instance.AddItem(newItem);
    }
    private InventoryItem CopyItem(InventoryItem item)
    {
        InventoryItem newItem = new InventoryItem(item);
        newItem.id = item.id;
        return newItem;
    }



    private void OnMouseDown()
    {
        Pickup();
    }
}
