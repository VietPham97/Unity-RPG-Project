using UnityEngine;

public class ItemPickup : Interactable 
{
	public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picking up an item.");
        // TODO Add to inventory
        Destroy(gameObject);
    }
}
