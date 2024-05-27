using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField]private Transform playerTransform;
    [SerializeField]private Vector3 offset;
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position = new Vector3(playerTransform.position.x+offset.x,playerTransform.position.y+offset.y,playerTransform.position.z + offset.z );        
    }
}
