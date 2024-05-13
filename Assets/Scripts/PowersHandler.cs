using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersHandler : MonoBehaviour
{
    [SerializeField]private GameObject[] powers;
    public GameObject power;
    private Player player;
    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    void Update()
    {
/*        if (player.getPowerName == "Rage")
        {
            power = powers[1];
        }
        else if (player.getPowerName=="Calm") 
        {
            power= powers[0];
        }*/
    }
}
