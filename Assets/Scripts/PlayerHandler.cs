using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    //Objects of different Scripts
    private ForwardButton forwardButton;
    private BackwardButton backwardButton;
    private JumpButton jumpButton;
    private Player player;

    public bool forwardIsPressed;
    public bool backwardIsPressed;
    public bool jumpIsPressed;
    

    void Start()
    {
        forwardButton = FindAnyObjectByType<ForwardButton>();
        backwardButton = FindAnyObjectByType<BackwardButton>();
        jumpButton = FindAnyObjectByType<JumpButton>();
        player = FindAnyObjectByType<Player>();
    }

    void Update()
    {
        checkButtonsPressed();
    }

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
}
