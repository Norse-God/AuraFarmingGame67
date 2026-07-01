using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventorySlot : MonoBehaviour
{
    public UnityEngine.UI.Image Item_Image;
    public item item;

    public void AddItem(item newItem)
    {
        item = newItem;
        Item_Image.sprite = item.icon;
        Item_Image.gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        item = null;
        Item_Image.gameObject.SetActive(false);
    }

}
