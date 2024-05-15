using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    //Objects of different Scripts
    private ForwardButton forwardButton;
    private BackwardButton backwardButton;
    private JumpButton jumpButton;
    private PowersHandler powersHandler;
    private Player playerObject;
    private PlayerHandler playerHandler;

    [SerializeField] private Animator playerAnimator;
    [SerializeField]private GameObject platform;
    private PowerButton powerButton;
    [SerializeField] private GameObject powersAnimations;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject power;
    public GameObject getPower() { return power; }
    [SerializeField] private GameObject spawnLocation;
    [SerializeField] private GameObject powerUpButton;
    public bool forwardIsPressed;
    public bool backwardIsPressed;
    public bool jumpIsPressed;
    private float damage=20f;
    private bool isRespawned;
    public bool getIsRespawned 
    {
        get { return isRespawned; }
    }
    [SerializeField]private Image healthBar;
    [SerializeField]public Image powerBar;

    void Start()
    {
        player.transform.position = spawnLocation.transform.position;
        powerButton = FindAnyObjectByType<PowerButton>();
        powerBar.color = Color.white;
        powerBar.fillAmount = 0;
        powersHandler = FindAnyObjectByType<PowersHandler>();
        forwardButton = FindAnyObjectByType<ForwardButton>();
        backwardButton = FindAnyObjectByType<BackwardButton>();
        jumpButton = FindAnyObjectByType<JumpButton>();
        playerObject = FindAnyObjectByType<Player>();
    }

    void Update()
    {
        if (powersHandler == null) 
        {
            powersHandler = FindAnyObjectByType<PowersHandler>();
        }
        EnablePlayerAnimations();
        checkButtonsPressed();
        EnablePlantAnimations(playerObject);

        if (playerObject.getIsHurt) 
        {
            HealthReduced(healthBar,damage);
        }
        if (playerObject.getPowerName == "Rage" && playerObject.getPowerSelected)
        {
            powerBar.fillAmount = 1;
            powerBar.color = Color.red;
        }
        else if (playerObject.getPowerName=="Calm" && playerObject.getPowerSelected) 
        {   
            powerBar.fillAmount = 1;
            powerBar.color = Color.blue;
        }
        if (playerObject.collectedPowerUp && powerBar.fillAmount!=1) 
        {
            FillPowerBar(30);
        }
        if (powerButton==null) 
        {
            powerButton= FindAnyObjectByType<PowerButton>();
        }
        if (powerButton!=null) 
        {
            if (powerButton.isPressed) 
            {
                Debug.Log("Pressed");
                ReducePowerBar(70);
            }
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

    #region EnablePlayerAnimations()
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

        if (playerObject.getPowerName == "Rage")
        {
            power = Resources.Load<GameObject>("Rage");
            powerUpButton.SetActive(true);    
        }
        else if (playerObject.getPowerName == "Calm") 
        {
            power = Resources.Load<GameObject>("Calm");
            powerUpButton.SetActive(true);
        }

    }

    #endregion

    #region HealthReduced
    private void HealthReduced(Image healthBar,float damage) 
    {
        Respawn(healthBar);
        healthBar.fillAmount -= (damage/100)*Time.deltaTime;
        if (healthBar.fillAmount<=0.4) 
        {
            healthBar.color = Color.red;
        }
    }

    #endregion
    private void Respawn(Image health)
    {
        if (health.fillAmount == 0)
        {
            player.gameObject.transform.position = spawnLocation.transform.position;
            isRespawned = true;
            SceneManager.LoadScene(0);
        }
    }

    public void FillPowerBar(int amount) 
    {
        powerBar.fillAmount += (amount/100)*Time.deltaTime;
    }
    public void ReducePowerBar(int amount) 
    {
        powerBar.fillAmount -= (amount/100)*Time.deltaTime;

    }

}
