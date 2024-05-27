using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    private PlayerHandler2 playerHandler;

    void Start()
    {
        playerHandler = FindAnyObjectByType<PlayerHandler2>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            playerHandler.IncreaseHealth(this.gameObject.tag);
            Destroy(this.gameObject);
        }
    }
   
}
