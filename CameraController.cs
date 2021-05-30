using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 offset;

    public Transform transformToFollow;
    public float smoothing = 5f;

    void Start()
    {
        offset = transform.position - transformToFollow.position;
    }

    
    void LateUpdate()
    {
        Vector3 targetCameraPosition = transformToFollow.position + offset;
        transform.position = Vector3.Lerp(transform.position,
            targetCameraPosition, smoothing * Time.deltaTime);
    }
}
