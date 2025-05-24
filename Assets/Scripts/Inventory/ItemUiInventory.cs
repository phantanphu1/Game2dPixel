using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ItemUiInventory : MonoBehaviour
{
    private InventoryItem item;
    [SerializeField]
    private Image _imgItem;

    [SerializeField]
    private TextMeshProUGUI _textMesh;
    public void SetItem(InventoryItem item)
    {
        Debug.Log($"SetItem: {JsonUtility.ToJson(item)}");
        _imgItem.sprite = item.image;
        _textMesh.text = item.value.ToString();
        PlayerPrefs.Save();
        this.item = item;

    }
    public void Remove()
    {
        InventoryManager.Instance.MoveItem(item);
        gameObject.SetActive(false);
    }
    public void UserItem()
    {
        Remove();
        InventoryManager.Instance.Damage();


        // FindObjectOfType<GameManager>().AddDamage(item.value);
    }
}
