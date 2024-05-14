using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersHandler : MonoBehaviour
{
    [SerializeField]private GameObject powerLocation;
    private GameObject power;
    bool called = false;
    private Player player;
    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    void Update()
    {

            FlipPosition(player);
    }

    private void FlipPosition(Player player) 
    {
            if (player.isFlipped==true && called!=true)
            {
                powerLocation.transform.Rotate(0, 180f, 0);
                called = true;
            }

            if (player.isFlipped==false && called) 
            {
            powerLocation.transform.Rotate(0, -180f, 0);
            called= false;
            }
    }


    private void Attack() 
    {
    
    }
}