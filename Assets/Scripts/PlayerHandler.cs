using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    //Objects of different Scripts
    private ForwardButton forwardButton;
    private BackwardButton backwardButton;
    private JumpButton jumpButton;
    private PowersHandler powersHandler;
    private Player player;

    [SerializeField]private GameObject platform;
    [SerializeField] private GameObject powersAnimations;
    [SerializeField] private GameObject power;
    public bool forwardIsPressed;
    public bool backwardIsPressed;
    public bool jumpIsPressed;

    

    void Start()
    {
        powersHandler = FindAnyObjectByType<PowersHandler>();
        forwardButton = FindAnyObjectByType<ForwardButton>();
        backwardButton = FindAnyObjectByType<BackwardButton>();
        jumpButton = FindAnyObjectByType<JumpButton>();
        player = FindAnyObjectByType<Player>();
    }

    void Update()
    {
        checkButtonsPressed();
        EnableAnimations(player);
    }

    //Checks if movement buttons are pressed
    private void checkButtonsPressed() 
    {
        if (forwardButton.isPressed)
        {
            forwardIsPressed = true;
        }
        else
        {
            forwardIsPressed = false;
        }
        if (backwardButton.isPressed)
        {
            backwardIsPressed = true;
        }
        else
        {
            backwardIsPressed = false;
        }
        if (jumpButton.isPressed)
        {
            jumpIsPressed = true;
        }
        else
        {
            jumpIsPressed = false;
        }
    }

    //Enables the platform animations
    private void EnableAnimations(Player player) 
    {
        if (player.getIsOnPlatform) 
        {
            platform.SetActive(true);
            if (player.getPowerSelected) 
            {
                GetPower();
                powersAnimations.SetActive(false);
            }
            
        }
    }

    private void GetPower() 
    {

        if (player.getPowerName=="Rage" || player.getPowerName=="Calm") 
        {
            power = powersHandler.power;
        }
    
    }
}
