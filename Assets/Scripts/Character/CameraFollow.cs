using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed;

    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    private bool follow = true;

    void LateUpdate()
    {
        if (!Application.isPlaying)
        {
            transform.localPosition = offset;
        }

        if(follow)
        {
            FollowTarget(target);
        }
    }

    private void FollowTarget(Transform target)
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    }

    public void SetFollow(bool active)
    {
        follow = active;
    }
}
