using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WereWolfEnemy : MonoBehaviour
{

    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    private Rigidbody2D skeletonRb;
    private SpriteRenderer spriteRenderer;
    [SerializeField]private float speed = 5f;
    private bool reachedPoint1;
    private bool reachedPoint2;
    [SerializeField]private float distance1;
    [SerializeField] private float distance2;
    private Animator animator; 
    void Start()
    {
        animator = GetComponent<Animator>();
        skeletonRb = GetComponent<Rigidbody2D>();
        skeletonRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        distance1 = Vector3.Distance(this.transform.position, point1.position);
        distance2 = Vector3.Distance(this.transform.position, point2.position);
        Walk(point1,point2);
    }

    private void Walk(Transform point1,Transform point2) 
    {
        animator.SetBool("IsWalking",true);

        if (!reachedPoint1) 
        {
            Debug.Log("entered");
            transform.position = Vector3.MoveTowards(transform.position,point1.position,speed*Time.deltaTime);
            reachedPoint1 = true;
        }
    }

}
