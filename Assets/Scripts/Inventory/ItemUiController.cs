using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUiController : MonoBehaviour
{
    public Item item;
    public void SetItem(Item item)
    {
        this.item = item;
    }
    public void Remove()
    {
        InventoryManager.Instance.MoveItem(item);
        Destroy(this.gameObject);
    }
    public void UserItem()
    {
        Remove();
        FindObjectOfType<GameManager>().AddDamage(item.valueHp);
    }
}
