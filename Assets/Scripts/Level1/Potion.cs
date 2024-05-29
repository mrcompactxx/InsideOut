using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private PlayerHandler playerHandler;
    void Start()
    {
        playerHandler = FindAnyObjectByType<PlayerHandler>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            Debug.Log("hello");
            playerHandler.HealthIncrease();
            Destroy(gameObject);
        }
    }
}
