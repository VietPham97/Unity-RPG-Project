using UnityEngine;

public class Interactable : MonoBehaviour 
{
    public float radius = 3f; // how close player need to be to interact with the object

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
