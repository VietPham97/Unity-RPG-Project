using UnityEngine;

public class PlayerStats : CharacterStats
{
    void Start()
    {
        EquipmentManager.Instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
			armor.AddModifier(newItem.armorModifier);
			damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }

    public override void Die()
    {
        base.Die();
        // TODO Implement killing effect
        PlayerManager.Instance.KillPlayer();
    }
}
