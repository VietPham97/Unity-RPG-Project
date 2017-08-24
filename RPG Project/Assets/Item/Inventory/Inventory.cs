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

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.LogWarning("Not enough room.");
                return false;
            }

            items.Add(item); // Add function of the List 

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke(); // Want the UI to update
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item); // Remove function of the List

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke(); // Want the UI to update
	}
}
