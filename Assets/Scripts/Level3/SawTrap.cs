using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : MonoBehaviour
{
    [SerializeField]private GameObject point1;
    [SerializeField]private GameObject point2;
    [SerializeField]private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField]private bool reachedPoint1;
    [SerializeField]private bool reachedPoint2;
    void Start()
    {
        reachedPoint1 = true;
        reachedPoint2 = false;
        rotationSpeed = 20f;
        speed = 3.3f;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Rotate(0, 0, rotationSpeed);

        if (!reachedPoint1)
        {
            transform.position = Vector3.MoveTowards(transform.position, point2.transform.position, speed * Time.deltaTime);
            if (transform.position.x==point2.transform.position.x) 
            {
                reachedPoint2 = false;
                reachedPoint1 = true;
            }
            
        }
        if (!reachedPoint2) 
        {
            transform.position = Vector3.MoveTowards(transform.position, point1.transform.position, speed * Time.deltaTime);
            if (transform.position.x == point1.transform.position.x)
            {
                reachedPoint2 = true;
                reachedPoint1 = false;
            }
        }
    }
}
