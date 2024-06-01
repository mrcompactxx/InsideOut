using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin3 : MonoBehaviour
{
    private CoinsHandler coinsHandler;
    void Start()
    {
        coinsHandler = FindAnyObjectByType<CoinsHandler>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            coinsHandler.IncreaseAmount();
            Destroy(gameObject);
        }
    }
}
