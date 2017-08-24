﻿using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour 
{
    public Image icon; // Assign the icon object in the children to this field

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
