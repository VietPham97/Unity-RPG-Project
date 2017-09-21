using UnityEngine;

public class Interactable : MonoBehaviour 
{
    public float radius = 3f; // how close player need to be to interact with the object
    public Transform interactionTransform;

    bool isFocus;
    Transform player;

    bool hasInteracted;

    public virtual void Interact()
    {
		// This method is meant to be overwritten
    }

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            var distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
	{
        isFocus = false;
        player = null;
        hasInteracted = false;
	}

    private void OnDrawGizmosSelected()
    {
        // Get rid of Null Reference Exception
        if (interactionTransform == null)
            interactionTransform = transform;
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
