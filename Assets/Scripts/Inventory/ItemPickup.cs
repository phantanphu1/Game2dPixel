using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public void Pickup()
    {
        this.gameObject.SetActive(false);
        // thêm vật phẩm vào kho đồ
        InventoryManager.Instance.AddItem(item);
    }
    private void OnMouseDown()
    {
        Pickup();
    }
}
