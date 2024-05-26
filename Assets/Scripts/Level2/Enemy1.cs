using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private bool collidedPlayer;
    private Animator animator;
    [SerializeField]private GameObject player;
    private Player1 player1;
    [SerializeField]private float speed;
    void Start()
    {
        player1 = FindAnyObjectByType<Player1>();
        animator = GetComponent<Animator>();
        speed = 5f;
    }

    void Update()
    {
        Attack();
    }

    private void Attack() 
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance<10f) 
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
        }
        if (collidedPlayer) 
        {
            player1.ReduceHealth(45);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            collidedPlayer = true;
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collidedPlayer = false;
        }
    }

}
