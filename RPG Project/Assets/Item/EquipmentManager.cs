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
    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.Instance;

        var numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length; // Get the length of EquipmentSlot enum
        currentEquipment = new Equipment[numSlots]; // create a new array of type Equipment
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot; // get the index of the equiped item or newItem in EquipmentSlot enum

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        currentEquipment[slotIndex] = newItem; // set the currentEquipment to the newItem
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            var oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}
