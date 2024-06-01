using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPrefab : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 23f;
    public bool isCollidedWithEnemy;
    [SerializeField]private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        if (player.transform.localScale==new Vector3(1,1,1)) 
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2 (-speed, rb.velocity.y);
        }
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slime")
        {
            isCollidedWithEnemy = true;

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.healthBarParent.SetActive(true);
                enemy.HealthBar();
                if (enemy.healthBar.fillAmount == 0)
                {
                    enemy.Die();
                }
            }
            Destroy(this.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slime")
        {
            isCollidedWithEnemy = false;
        }
    }
}
