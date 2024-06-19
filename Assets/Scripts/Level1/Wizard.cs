using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    internal static Wizard Instance;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            StartCoroutine(DialogHandler.Instance.ReadLines());

        }
    }
}
