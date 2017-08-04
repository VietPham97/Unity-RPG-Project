using UnityEngine;

public class CameraController : MonoBehaviour 
{
    public Transform target; // Player

    public Vector3 offset;
    public float pitch = 2f;

    float currentZoom = 10f;

    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}
