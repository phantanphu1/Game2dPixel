using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // dùng singleton
    public static InventoryManager Instance { get; private set; }
    public List<Item> items = new List<Item>();
    public Transform itemHolder;
    public GameObject itemPrefab;
    public GameObject OpenInven;
    public bool isInventory = false;
    public Toggle enableRemoveButton;
    private void Awake()
    {
        if (Instance != null || Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }
    public void AddItem(Item item)
    {
        items.Add(item);
        DisplayInventory();
    }
    public void MoveItem(Item item)
    {
        items.Remove(item);
    }
    public void DisplayInventory()
    {
        foreach (Transform item in itemHolder)
        {
            Destroy(item.gameObject);
        }
        foreach (Item item in items)
        {
            GameObject obj = Instantiate(itemPrefab, itemHolder);
            var itemName = obj.transform.Find("NameItem").GetComponent<TextMeshProUGUI>();
            var itemImage = obj.transform.Find("Image").GetComponent<Image>();
            itemName.text = item.itemName;
            itemImage.sprite = item.image;
            obj.GetComponent<ItemUiController>().SetItem(item);
            Debug.Log($"Item: {item.itemName}, Price: {item.id}");
        }
        EnableRemoveButton();
    }
    public void OpenInventory()
    {
        OpenInven.SetActive(true);
        isInventory = true;
        Time.timeScale = 0;
    }
    public void ExitInventory()
    {
        OpenInven.SetActive(false);
        isInventory = false;
        Time.timeScale = 1;
    }
    void EnableRemoveButton()
    {
        if (enableRemoveButton.isOn)
        {
            foreach (Transform item in itemHolder)
            {
                item.transform.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in itemHolder)
            {
                item.transform.Find("RemoveButton").gameObject.SetActive(false);
            }
        }

    }
    public bool IsInventory()
    {
        return isInventory;
    }
}
