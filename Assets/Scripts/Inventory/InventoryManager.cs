using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // dùng singleton
    public static InventoryManager Instance { get; private set; }
    [SerializeField]
    private InventoryItemScriptableObject inventoryItemConfig;
    public InventoryItemScriptableObject InventoryItemConfig => inventoryItemConfig;
    public Transform itemHolder;
    public GameObject itemPrefab;
    public GameObject OpenInven;
    public bool isInventory = false;
    public Toggle enableRemoveButton;
    private List<InventoryItem> _lsInventoryItem = new List<InventoryItem>();
    private string _keyData = "keydata";
    private List<ItemUiInventory> lsItemUIInventory = new List<ItemUiInventory>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void AddItem(InventoryItem item)
    {
        // if (CheckContainItem(item))
        // {
        //     var count = _lsInventoryItem.Count;
        //     for (int i = 0; i < count; i++)
        //     {
        //         if (_lsInventoryItem[i].id == item.id)
        //         {
        //             _lsInventoryItem[i].value += item.value;
        //         }
        //     }
        // }
        Debug.Log($"AddItem {JsonUtility.ToJson(item)}");
        _lsInventoryItem.Add(item);
        // SaveData();
    }
    public void SaveData()
    {
        var data = JsonUtility.ToJson(_lsInventoryItem);
        PlayerPrefs.SetString(_keyData, data);
        PlayerPrefs.Save();
    }
    public void GetData()
    {
        string json = PlayerPrefs.GetString(_keyData);
        Debug.Log($"Loading JSON from PlayerPrefs: {json}");
        // var loadData = JsonUtility.FromJson<>(json);
    }
    public void MoveItem(InventoryItem item)

    {

        // _lsInventoryItem.Remove(item);

        Debug.Log($"_lsInventoryItem:{_lsInventoryItem.Count} {JsonUtility.ToJson(item)}");
        if (CheckContainItem(item))
        {
            _lsInventoryItem.Remove(item);

        }
    }
    public void Damage()
    {
        foreach (var itemInventory in _lsInventoryItem)
        {
            FindObjectOfType<GameManager>().AddDamage(itemInventory.value);

        }
    }
    private bool CheckContainItem(InventoryItem item)
    {

        if (_lsInventoryItem == null || _lsInventoryItem.Count <= 0)
        {
            return false;
        }
        foreach (var itemInventory in _lsInventoryItem)
        {
            if (itemInventory.id == item.id)
            {
                return true;
            }
        }
        return false;
    }
    public void DisplayInventory()
    {
        foreach (var item in lsItemUIInventory)
        {
            item.gameObject.SetActive(false);
        }
        var countInventoryItem = _lsInventoryItem.Count;
        var countUIInventory = lsItemUIInventory.Count;
        if (countInventoryItem - countUIInventory > 0)
        {
            var count = countInventoryItem - countUIInventory;
            for (int i = 0; i < count; i++)
            {
                CreateInstanceUIInventory();
            }
        }

        for (int i = 0; i < _lsInventoryItem.Count; i++)
        {
            lsItemUIInventory[i].SetItem(_lsInventoryItem[i]);
            lsItemUIInventory[i].gameObject.SetActive(true);

        }


    }
    private void CreateInstanceUIInventory()
    {
        GameObject obj = Instantiate(itemPrefab, itemHolder);
        var classname = obj.GetComponent<ItemUiInventory>();
        if (classname != null)
        {

            lsItemUIInventory.Add(classname);
            classname.gameObject.SetActive(false);

        }
    }
    public void OpenInventory()
    {
        OpenInven.SetActive(true);
        isInventory = true;
        Time.timeScale = 0;
        DisplayInventory();

    }
    public void ExitInventory()
    {
        OpenInven.SetActive(false);
        isInventory = false;
        Time.timeScale = 1;
    }
    public void EnableRemoveButton()
    {
        if (enableRemoveButton.isOn)
        {
            foreach (Transform item in itemHolder)
            {
                item.transform.Find("item (1)/RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in itemHolder)
            {
                item.transform.Find("item (1)/RemoveButton").gameObject.SetActive(false);
            }
        }

    }
    public bool IsInventory()
    {
        return isInventory;
    }
}

