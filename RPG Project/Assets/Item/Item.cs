﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject 
{
    new public string name = "New Item";
    public Sprite icon;
    public bool isDefaultItem;

    public virtual void Use()
    {
        // Use the item
        // Something might happen

        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.Instance.Remove(this);
    }
}
