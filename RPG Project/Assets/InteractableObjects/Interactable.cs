using UnityEngine;

public class Interactable : MonoBehaviour 
{
    public float radius = 3f; // how close player need to be to interact with the object

    bool isFocus;
    Transform player;

    bool hasInteracted;

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            var distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Debug.Log("INTERACT");
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
