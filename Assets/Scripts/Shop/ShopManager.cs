using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance { get; private set; }
    [SerializeField]
    private ShopItemScriptableObject shopItemConfig;
    public ShopItemScriptableObject ShopItemConfig => shopItemConfig;
    [SerializeField] private InventoryItemScriptableObject invenItemConfig;
    public GameObject itemPrefab;
    public Transform itemHolder;
    public GameObject openShop;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
    }

    public void LoadDataShop()
    {
        foreach (Transform child in itemHolder)
        {
            Destroy(child.gameObject);
        }
        foreach (var item in ShopItemConfig.LsShopItem)
        {
            GameObject obj = Instantiate(itemPrefab, itemHolder);
            var tam = obj.GetComponent<ShopItemUi>();
            tam.SetItem(item);
        }
    }
    public void RemoveItemFromShop(ShopItem item)
    {
        var _countItemShop = shopItemConfig.LsShopItem;
        for (int i = 0; i < _countItemShop.Count; i++)
        {
            if (_countItemShop[i].id == item.id)
            {
                // shopItemConfig.LsShopItem.RemoveAt(i);


                Debug.Log($"gai tri:{JsonUtility.ToJson(shopItemConfig.LsShopItem[i])}");
                InventoryItem newInventoryItem = new InventoryItem();

                // 2. Copy relevant data from the ShopItem to the new InventoryItem
                newInventoryItem.id = item.id;
                newInventoryItem.itemName = item.itemName;
                newInventoryItem.icon = item.icon;
                newInventoryItem.image = item.image;
                newInventoryItem.value = item.value;

                // invenItemConfig.LsInventoryItem.Add(newInventoryItem);
                InventoryManager.Instance.AddItem(newInventoryItem);

                // break;
            }
        }
        LoadDataShop();
    }

    public void AddItemFromInventory(InventoryItem item)
    {
        invenItemConfig.LsInventoryItem.Add(item);


    }
    public void OpenShop()
    {
        openShop.SetActive(true);
        Time.timeScale = 0;
        LoadDataShop();

    }
    public void ExitShop()
    {
        openShop.SetActive(false);
        Time.timeScale = 1;
    }
}
