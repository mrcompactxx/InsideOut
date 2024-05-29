using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftLower : MonoBehaviour
{
    [SerializeField] private GameObject lowerPos;
    private bool playerArrived;
    private GameObject player;
    [SerializeField]private float speed;
    void Start()
    {
        speed = 12f;
    }

    void Update()
    {
        if (playerArrived) 
        {
            
            Vector3 pos = new Vector3(transform.position.x,lowerPos.transform.position.y,transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            player = collision.gameObject;
            playerArrived = true;
        }
    }

}
