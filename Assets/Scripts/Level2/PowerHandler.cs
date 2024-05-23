using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerHandler : MonoBehaviour
{
    private Player1 player;

    [SerializeField]private GameObject playerObj;
    private SpriteRenderer playerSpriteRenderer;
    private bool enabledButton;
    private PowerButton powerButton;
    private GameObject power;
    private GameObject summonedEnemy;
    [SerializeField]private GameObject powerButtonGameObject;
    private bool changed;
    private bool isSummoned;
    void Start()
    {
        powerButton = FindAnyObjectByType<PowerButton>();
        player = FindAnyObjectByType<Player1>();
    }

    void Update()
    {

        if (playerObj.transform.localScale== new Vector3(1,1,1) && !changed) 
        {
            transform.Rotate(0,0f,0);
            changed = true;
        }
        if (playerObj.transform.localScale == new Vector3(-1, 1, 1) && changed)
        {
            transform.Rotate(0, 180f, 0);
            changed = false;
        }

        if (player.powerSelected && !enabledButton) 
        {
            powerButtonGameObject.SetActive(true);
            enabledButton = true;
            LoadPowerPrefab();
        }

        if (powerButton==null) 
        {
            powerButton = FindAnyObjectByType<PowerButton>();
        }

        if (powerButton!=null) 
        {
            if (powerButtonGameObject != null && powerButton.isPressed)
            {
                if (!isSummoned)
                {
                    summonedEnemy = Instantiate(power,transform.position,Quaternion.identity);
                    summonedEnemy.transform.position = new Vector3(summonedEnemy.transform.position.x,summonedEnemy.transform.position.y,-2.09f);
                    isSummoned = true;
                    
                }
            }   
        }

       
    }

    private void LoadPowerPrefab() 
    {
        if (player.powerSelected.tag=="Summon") 
        {
            power = Resources.Load<GameObject>("NightBorne");
        }
    }


}
