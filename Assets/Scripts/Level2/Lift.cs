using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField]private Transform point;
    [SerializeField]private float speed;
    private bool move;
    void Start()
    {
        speed = 10;
    }

    void Update()
    {
        if (move) 
        {
            transform.position = Vector3.MoveTowards(transform.position, point.position, speed*Time.deltaTime);
            if (transform.position==point.position) 
            {
                Destroy(gameObject, 1f);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            move = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
    }
}
