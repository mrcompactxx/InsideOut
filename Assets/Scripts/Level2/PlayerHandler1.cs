using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler1 : MonoBehaviour
{
    [SerializeField]private GameObject powers;
    private Player1 player;
    
    void Start()
    {
        player = FindAnyObjectByType<Player1>();
    }

    void Update()
    {
        DestroyPowers();
    }

    private void DestroyPowers()
    {
        if (player.powerSelected!=null) 
        {
            Destroy(powers);
        }
    }

}
