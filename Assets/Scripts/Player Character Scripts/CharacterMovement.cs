/*
 *  Author: Lochlan Kennedy
 *  Date: 11/06/2018
 *  Version Control Repository: https://github.com/Pharah-tato/Cronoblast
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT IS FOR PLAYER 1 WHEN IN Co-Op MODE (Didn't refractor script/class name due to potential screw ups with unity, saving me from having to restart the project)

[RequireComponent(typeof(Rigidbody2D))]// requires the object to have components of SpriteRenderer and Rigidbody2D
public class CharacterMovement : MonoBehaviour
{

    public bool isUsingMouse = false; // checks if the mouse is being used as the input.

    //Collapsed (Press the + Button to Uncollapse)
    #region Input_Vectors (Contains All Input Vector Variables) 
    Vector3 keyboardMovementInput = Vector3.zero; // for keyboard walk
    Vector3 mouseInput = Vector3.zero; // for aiming the gun with the mouse
    Vector3 previousMousePosition = Vector3.zero; //
    Vector3 gamepadController1Input = Vector3.zero; // gamepad for player 1
    Vector3 gamepadController2Input = Vector3.zero; // second gamepad if there are two players and both are using gamepads (controllers)

    Vector3 aimInputGamepad1 = Vector3.zero; // for aiming the gun with gamepad 1
    Vector3 aimInputGamepad2 = Vector3.zero; // for aiming the gun with gamepad 2
    #endregion

    //Collapsed (Press the + Button to Uncollapse)
    #region Player_Stat_Variables
    public int powerResourceValue = 100; // the amount of power the player has to begin with
    public int playerHealth = 1000; // the amount of health the player has. will be displayed as a percentage on the UI/HUD

    [SerializeField]
    int enemiesKilled = 0; //This stores the amount of enemies killed and will be used to dictate which wave the player is on, to then generate harder enemies or more enemies.

    public int waveNumber = 1; // sets the round number defaulted to wave 1.

    public int difficultyMultiplier { get; private set; } //this is used in tandem with 'enemiesKilled' to dictate the health stats of enemies as waves progress. It will be accessed by the enemy script and used to add to their health. 

    [SerializeField]
    float movementSpeed = 4f; //multiplier for the player's speed
    #endregion

    //Collapsed (Press the + Button to Uncollapse)
    #region Objects_And_Components
    SpriteRenderer spriteRenderer; // stores the sprite renderer for the player

    [SerializeField]
    GameObject bullet; // stores the bullet prefab gameobject information.
    GameObject bulletClone; //used to store the information of the instantiated bullet prefab

    [SerializeField]
    GameObject gun; // stores the informaton for the gun gameobject.

    Rigidbody2D rigB2D;// players rigidbody container
    #endregion




    /*********************AWAKE*********************************/
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // stores the attached spriterenderer information.
        rigB2D = GetComponent<Rigidbody2D>(); // stores the attached rigidbody information
        difficultyMultiplier = 1; // defaults the multiplier to x1
    }
    /*********************END AWAKE*********************************/


    /*********************START*********************************/
    // Use this for initialization
    void Start()
    {
        previousMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);// stores the starting location of the mouse, will be removed once the settings options are set up.


    }
    /*********************END START*********************************/


    /*********************UPDATE*********************************/
    // Update is called once per frame
    void Update()
    {
        Movement(); // calls the movement function.
        AimWithGamepad(); // sets the input vectors related to the gamepad 'aimInput'
        AimWithMouse(); // sets the input vectors related to the mouse 'mouseInput'
        ShootChecker();// calls the ShootChecker Function which checks if input is supplied.
        
    }
    /*********************END UPDATE*********************************/


    /*********************SHOOT CHECKER*********************************/
    void ShootChecker()
    {
        if (isUsingMouse == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot(mouseInput); // calls shoot function and passes the current mouse position.
            }
            
        }
        else
        {
            if (Input.GetAxis("RTP1") > 1f)
            {
                Shoot(aimInputGamepad1); // calls shoot function and passes the current gamepad 1 right stick axis inputs.
            }
        }


    }
    /*********************END SHOOT CHECK*********************************/


    /*********************SHOOT*********************************/
    void Shoot(Vector3 inputs)
    {
        bulletClone = Instantiate(bullet, gun.transform.position, gun.transform.rotation, gameObject.transform);// spawns a bullet and sets it as a child of the player.
        bulletClone.GetComponent<Rigidbody2D>().AddForce(inputs.normalized * 15f, ForceMode2D.Impulse); // applies force to the bullet in the direction of the aim input.

    }
    /*********************END SHOOT*********************************/


    /*********************AIM WITH GAMEPAD (XBOX CONTROLLER)*********************************/
    void AimWithGamepad()
    {
        aimInputGamepad1 = new Vector3(Input.GetAxis("RStickHorizontalP1"), Input.GetAxis("RStickVerticalP1"), 0f); //sets aim input to the current axes of the right stick on gamepad 1. (can be player 1 or 2)
    }
    /*********************END AIM WITH GAMEPAD (XBOX CONTROLLER)*********************************/


    /*********************AIM WITH MOUSE*********************************/
    void AimWithMouse()
    {
        mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition); //sets mouseInput to the current mouse position and uses the camera to convert it to world points. (can be player 1 or 2)
        if (mouseInput != previousMousePosition)
        {
            isUsingMouse = true;

        }

        if (mouseInput == previousMousePosition)
        {
            isUsingMouse = false;
            // if mouse position is equal to the starting positon of the mouse then player is not using the mouse
            // this is really bad as there will be a position that will cause issues when playing potentially freezing the aim
            //if the user uses that position anytime during gameplay
            //I will be using a settings file anyway so this is only temporary.
        }
    }
    /*********************END AIM WITH MOUSE*********************************/


    /*********************MOVEMENT*********************************/
    void Movement()
    {
        keyboardMovementInput = new Vector3(Input.GetAxis("KeyboardHorizontal"), Input.GetAxis("KeyboardVertical"), 0f); // sets the vector to the current x and y axes supplied by the keyboard
        gamepadController1Input = new Vector3(Input.GetAxis("HorizontalP1"), Input.GetAxis("VerticalP1"), 0f); // sets the vector to the current x and y axes supplied by gamepad1
        if (gun != null) // if the gun gameobject variable is not equal to null then continue.
        {
            if (isUsingMouse == true)
            {
                rigB2D.velocity = movementSpeed * keyboardMovementInput; // sets movement velocity
                if (mouseInput.magnitude != 0f)
                {
                    Vector3 tempVector = new Vector3(mouseInput.x, mouseInput.y, 0f);//zeroes out the Z axis for aiming with the mouse.
                    gun.transform.up = tempVector.normalized;

                    if (mouseInput.x < 0)
                    {
                        spriteRenderer.flipX = true; // if aiming left with mouse then make sprite flip to the left

                    }
                    else if (mouseInput.x > 0)
                    {
                        spriteRenderer.flipX = false; // if aiming left with mouse then make sprite flip to the right

                    }
                }
            }
            else
            {
                rigB2D.velocity = movementSpeed * gamepadController1Input;
                if (aimInputGamepad1.magnitude != 0f)
                {
                    gun.transform.up = aimInputGamepad1.normalized;
                    if (aimInputGamepad1.x < 0)
                    {
                        spriteRenderer.flipX = true; // if aiming left then make sprite flip to the left.

                    }
                    else if (aimInputGamepad1.x > 0)
                    {
                        spriteRenderer.flipX = false;// if aiming right then make sprite flip to the right.

                    }
                }

            }
        }
    }
    /*********************END MOVEMENT*********************************/
}
