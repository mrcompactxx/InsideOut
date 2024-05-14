using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPrefab : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 10f;
    public bool isCollidedWithEnemy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Slime") 
        {
            isCollidedWithEnemy = true;
            
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null) 
            {
                enemy.healthBarParent.SetActive(true);
                enemy.HealthBar();
                if (enemy.healthBar.fillAmount==0) 
                {
                    enemy.Die();
                }
            }
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slime")
        {
            isCollidedWithEnemy = false;
        }
    }
}
