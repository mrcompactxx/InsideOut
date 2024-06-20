using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    private bool displayed;
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
        if (collision.gameObject.tag=="Player" && !displayed) 
        {
            StartCoroutine(DialogHandler.Instance.ReadLines());
            displayed = true;
        }
    }
}
