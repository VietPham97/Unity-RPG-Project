using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
    #region Singletom
    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than 1 instance of Inventory found!");
            return;
        }

		Instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        if (!item.isDefaultItem)
        {
			items.Add(item); // Add function of the List 
        }
    }

    public void Remove(Item item)
    {
        items.Remove(item); // Remove function of the List
    }
}
