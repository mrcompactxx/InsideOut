using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private PlayerHandler2 playerHandler;
    void Start()
    {
        playerHandler = FindAnyObjectByType<PlayerHandler2>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHandler.isHurt = true;
            playerHandler.trapName = this.gameObject.name;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHandler.isHurt = false;
            playerHandler.trapName = this.gameObject.name;
        }
    }
}
