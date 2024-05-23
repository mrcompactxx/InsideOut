using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]private GameObject enemy;
    private SkeletonEnemy skeletonEnemy;
    private Animator animator;
    [SerializeField] Transform castPoint;
    [SerializeField]private float distance;
    SpriteRenderer spriteRenderer;
    private bool attacked;
    private float speed;
    void Start()
    {
        speed = 8f;
        distance = 10f;
        animator = GetComponent<Animator>();
        enemy = GameObject.FindGameObjectWithTag("Skeleton Enemy");
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        skeletonEnemy = FindAnyObjectByType<SkeletonEnemy>();
    }

    void Update()
    {
        Attack(enemy);

        if (transform.position.x<=enemy.transform.position.x) 
        {
            spriteRenderer.flipX = false;
        }
        else 
        {
            spriteRenderer.flipX=true;
        }

        if (attacked) 
        {
            if (skeletonEnemy!=null) 
            {
                skeletonEnemy.ReduceHealth(34f);
            }
            
        }
    }

    private void Attack(GameObject enemy)
    {
        transform.position = Vector3.MoveTowards(transform.position,enemy.transform.position,speed*Time.deltaTime);
        if (attacked)
        {
            animator.SetBool("IsAttack", true);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsDead", false);
        }
        else 
        {
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsDead", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Skeleton Enemy") 
        {
            attacked = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Skeleton Enemy") 
        {
            attacked= false;
        }
    }
}
