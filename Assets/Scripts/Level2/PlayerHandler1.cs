using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler1 : MonoBehaviour
{
    [SerializeField]private GameObject power;
    [SerializeField]private GameObject spawnPoint;
    private Player1 player;
    [SerializeField]private GameObject playerObject;
    public SpriteRenderer spriteRenderer;
    private float speed;
    private PowerButton powerButton;
    private bool shoot;
    public bool changedPosition;
    public bool flipped;
    void Start()
    {
        powerButton = FindAnyObjectByType<PowerButton>();
        speed = 23f;
        spriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        player = FindAnyObjectByType<Player1>();
    }

    void Update()
    {
        if (powerButton==null) 
        {
            powerButton = FindAnyObjectByType<PowerButton>();
        }
        if (player.power != null) 
        {
            power = player.power;
        }
        if (powerButton!=null) 
        {
            if (powerButton.isPressed && !shoot)
            {
                Instantiate(power, spawnPoint.transform.position, Quaternion.identity);
                shoot = true;
            }
            else if (!powerButton.isPressed && shoot) 
            {
                shoot = false;
            }
        }

        if (spriteRenderer.flipX  && !flipped)
        {
            spawnPoint.transform.Rotate(0f, -180f, 0f);
            if (!changedPosition)
            {
                spawnPoint.transform.position = new Vector3(-spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
                changedPosition = true;
            }
            flipped = true;
        }
        else if (!spriteRenderer.flipX && flipped) 
        {
            spawnPoint.transform.Rotate(0f,180f,0f);

            if (!changedPosition)
            {
                spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
                changedPosition = false;
            }
            flipped = false;
        }
    }

    
    

}
