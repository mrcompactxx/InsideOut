using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField]private Transform playerTransform;
    [SerializeField]private Vector3 offset;
    [SerializeField]private float speed;
    void Start()
    {
        speed = 4f;
    }

    void LateUpdate()
    {
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(playerTransform.position.x + offset.x, playerTransform.position.y + offset.y, playerTransform.position.z + offset.z), speed * Time.deltaTime);

        transform.position = smoothedPosition; 
    }
}
