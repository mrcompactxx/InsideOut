using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour
{
    private GameObject position;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            transform.position = Vector3.MoveTowards(transform.position,position.transform.position,23f*Time.deltaTime);
        }
    }
}
