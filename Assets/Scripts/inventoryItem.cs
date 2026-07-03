using System;
using UnityEngine;
using UnityEngine.UI;

public class inventoryItem : MonoBehaviour
{
    public ItemSO ItemScriptebleObject;
    [SerializeField] Image Icon_Image;

    void Update()
    {
        Icon_Image.sprite = ItemScriptebleObject.icon;
    }

}
