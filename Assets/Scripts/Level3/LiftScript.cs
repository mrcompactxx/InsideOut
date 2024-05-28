using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour
{
    [SerializeField]private bool playerArrived;
    [SerializeField]private GameObject position;
    [SerializeField] private float speed;
    public float rotateSpeed;
    public GameObject chain,chainWheel;

    void Start()
    {
        rotateSpeed = 23f;
        speed = 10f;
    }

    void Update()
    {
        if (playerArrived) 
        {
        
            Vector3 pos = new Vector3(transform.position.x, position.transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, position.transform.position, speed * Time.deltaTime);

            if (transform.position.y!=pos.y) 
            {
                chainWheel.transform.Rotate(0, 0, rotateSpeed);
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            playerArrived = true;
        }
    }
}
