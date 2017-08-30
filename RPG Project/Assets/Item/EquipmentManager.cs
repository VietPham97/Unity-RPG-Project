using UnityEngine;

public class EquipmentManager : MonoBehaviour 
{
    #region Singleton
    public static EquipmentManager Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    Equipment[] currentEquipment;

    private void Start()
    {
        var numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length; // Get the length of EquipmentSlot enum
        currentEquipment = new Equipment[numSlots]; // create a new array of type Equipment
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot; // get the index of the equiped item or newItem in EquipmentSlot enum

        currentEquipment[slotIndex] = newItem; // set the currentEquipment to the newItem
    }
}
