using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;
    private float smoothing = 0.1f;

    void LateUpdate()
    {
        // Update position to smoothed position
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, smoothing);
    }
}
