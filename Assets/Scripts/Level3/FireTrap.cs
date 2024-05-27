using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrao : MonoBehaviour
{
    PlayerHandler2 playerHandler;
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
            playerHandler.isHurt = true;
            playerHandler.ReduceHealth(this.gameObject.name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            playerHandler.isHurt=false;
        }
    }
}
