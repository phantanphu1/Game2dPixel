using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUi : MonoBehaviour
{
    private ShopItem item;
    public TextMeshProUGUI valueItemShop;
    public Image imageItemShop;
    public Image iconItemShop;
    public void SetItem(ShopItem item)
    {
        iconItemShop.sprite = item.icon;
        imageItemShop.sprite = item.image;
        valueItemShop.text = item.value.ToString();
        this.item = item;
    }
    public void RemoveItemFromShop()
    {
        ShopManager.Instance.RemoveItemFromShop(item);
        Debug.Log($"item:{JsonUtility.ToJson(item)}");
        gameObject.SetActive(false);

    }
}
