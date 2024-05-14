using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPrefab : MonoBehaviour
{
    public bool collidedWithEnemy;
    void Start()
    {
        Destroy(gameObject,5f);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slime")
        {
            Destroy(this.gameObject);
        }

    }

}
