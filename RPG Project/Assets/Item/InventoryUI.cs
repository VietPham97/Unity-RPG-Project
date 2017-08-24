﻿using UnityEngine;

public class InventoryUI : MonoBehaviour 
{
    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI;
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
    }
}
