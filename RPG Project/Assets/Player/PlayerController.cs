using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public LayerMask movementMask;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                // TODO Move player to the hit point

                // TODO Stop focusing any objects
            }
        }
    }
}
