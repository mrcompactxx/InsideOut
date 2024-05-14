using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isCollided;
    public bool isHurt;
    private EnemyHandler enemyHandler;
    public bool getIsCollided 
    {
        get { return isCollided; }
    }
    void Start()
    {
        enemyHandler = FindAnyObjectByType<EnemyHandler>();
    }

    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            isCollided = true;
        }
        if (collision.gameObject.tag == "Rage" || collision.gameObject.tag == "Calm")
        {
            isHurt = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            isCollided=false;
        }
        if (collision.gameObject.tag=="Rage" || collision.gameObject.tag=="Calm") 
        {
            isHurt=false;
        }
    }


}
