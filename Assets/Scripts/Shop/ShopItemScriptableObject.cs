using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ShopItemConfig", menuName = "Shop/ListShopItem")]

public class ShopItemScriptableObject : ScriptableObject
{
    public List<ShopItem> LsShopItem;
}

[Serializable]
public class ShopItem
{
    public string id;
    public string itemName;
    public int value;
    public Sprite image;
    public Sprite icon;
    public ShopItem(ShopItem item)
    {
        this.id = item.id;
        this.itemName = item.itemName;
        this.value = item.value;
        this.image = item.image;
        this.image = item.icon;
    }
}
