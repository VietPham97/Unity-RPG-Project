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

    public SkinnedMeshRenderer targetMesh; // assign the 'Body' mesh of the Player on Unity Inspector window
    Equipment[] currentEquipment;
    SkinnedMeshRenderer[] currentMeshes;
    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.Instance;

        var numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length; // Get the length of EquipmentSlot enum
        currentEquipment = new Equipment[numSlots]; // create a new array of type Equipment
        currentMeshes = new SkinnedMeshRenderer[numSlots];
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

        SetEquipmentBlendShapes(newItem, 100);

        currentEquipment[slotIndex] = newItem; // set the currentEquipment to the newItem
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }
            var oldItem = currentEquipment[slotIndex];
            SetEquipmentBlendShapes(oldItem, 0);
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

    void SetEquipmentBlendShapes(Equipment item, int weight)
    {
        foreach (var blendShape in item.coveredMeshRegions)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape, weight);
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
