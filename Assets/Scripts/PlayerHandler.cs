using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    //Objects of different Scripts
    private ForwardButton forwardButton;
    private BackwardButton backwardButton;
    private JumpButton jumpButton;
    private PowersHandler powersHandler;
    private Player player;
 
    [SerializeField] private Animator playerAnimator;
    [SerializeField]private GameObject platform;
    [SerializeField] private GameObject powersAnimations;
    [SerializeField] private GameObject power;
    public bool forwardIsPressed;
    public bool backwardIsPressed;
    public bool jumpIsPressed;
    private float damage=20f;
    [SerializeField]private Image healthBar;

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
        if (powersHandler == null) 
        {
            powersHandler = FindAnyObjectByType<PowersHandler>();
        }
        checkButtonsPressed();
        EnablePlantAnimations(player);
        EnablePlayerAnimations();
        if (player.getIsHurt) 
        {
            HealthReduced(healthBar,damage);
        }
    }

    #region checkButtonsPressed
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
    #endregion


    #region EnablePlantAnimations
    //Enables the platform animations
    private void EnablePlantAnimations(Player player) 
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
    #endregion

    #region EnablePlayAnimations()
    private void EnablePlayerAnimations() 
    {
        playerAnimator.SetBool("IsIdle", true);
        playerAnimator.SetBool("IsWalk", false);
        playerAnimator.SetBool("IsJump", false);

        if (forwardIsPressed)
        {
            playerAnimator.SetBool("IsIdle", false);
            playerAnimator.SetBool("IsWalk", true);
            playerAnimator.SetBool("IsJump", false);
        }
        else if (backwardIsPressed) 
        {
            playerAnimator.SetBool("IsIdle", false);
            playerAnimator.SetBool("IsWalk", true);
            playerAnimator.SetBool("IsJump", false);
        }
        else if (jumpIsPressed)
        {
            playerAnimator.SetBool("IsIdle", false);
            playerAnimator.SetBool("IsWalk", false);
            playerAnimator.SetBool("IsJump", true);
        }
    }
    #endregion

    #region GetPowers()
    private void GetPower() 
    {

        if (player.getPowerName == "Rage")
        {
            power = Resources.Load<GameObject>("Rage");
        }
        else if (player.getPowerName == "Calm") 
        {
            power = Resources.Load<GameObject>("Calm");
        }
    }

    #endregion
    private void HealthReduced(Image healthBar,float damage) 
    {
    healthBar.fillAmount -= (damage/100)*Time.deltaTime;
        if (healthBar.fillAmount<=0.4) 
        {
            healthBar.color = Color.red;
        }
    }
}
