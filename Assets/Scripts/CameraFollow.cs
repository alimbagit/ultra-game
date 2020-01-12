using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // The position that that camera will be following.
    public float smoothing = 7f;        // The speed with which the camera will be following.

    public float correctDistance=4f;
    Vector3 offset;                     // The initial offset from the target.

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        if (target)
        {
            Vector3 correct1 = target.position - target.transform.TransformPoint(0, 0, correctDistance);
            Vector3 targetCamPos = target.position + offset - correct1;


            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}