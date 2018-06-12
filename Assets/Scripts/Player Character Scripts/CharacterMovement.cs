/*/
 *  Author: Lochlan Kennedy
 *  Date: 11/06/2018
 *  Version Control Repo: https://github.com/Pharah-tato/Cronoblast
/*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT IS FOR PLAYER 1 WHEN IN Co-Op MODE (Didn't refractor script/class name due to potential screw ups with unity saving me from having to restart the project)

[RequireComponent(typeof(Rigidbody2D))]// requires the parent object to have components of SpriteRenderer and Rigidbody2D
public class CharacterMovement : MonoBehaviour {

    [SerializeField]
    bool isUsingMouse = false;

    Vector3 keyboardAndMouseInput = Vector3.zero; // for keyboard walk
    Vector3 mouseInput = Vector3.zero; // mouse Aim
    Vector3 previousKeyboardAndMouseInput = Vector3.zero; //
    Vector3 gamepadController1Input = Vector3.zero; // gamepad for player 1
    //Vector3 gamepadController2Input = Vector3.zero; // gamepad for player 2

    Vector3 aimInput = Vector3.zero; // for aiming the gun

     SpriteRenderer spriteRenderer; // sprite renderer for the player
     

    [SerializeField]
    float movementSpeed = 4f; //multiplier for the player's speed

    Rigidbody2D rigB2D;// players rigidbody container

    [SerializeField]
    GameObject gun;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigB2D = GetComponent<Rigidbody2D>();
        
    }
    


	// Use this for initialization
	void Start () {
        previousKeyboardAndMouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        keyboardAndMouseInput = new Vector3(Input.GetAxis("KeyboardHorizontal"), Input.GetAxis("KeyboardVertical"),0f);
        gamepadController1Input = new Vector3(Input.GetAxis("HorizontalP1"), Input.GetAxis("VerticalP1"), 0f);
        mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(mouseInput != previousKeyboardAndMouseInput)
        {
            isUsingMouse = true;
             
        }

        if(mouseInput == previousKeyboardAndMouseInput)
        {
            isUsingMouse = false;
        }

        if(gun != null)
        {
            if (isUsingMouse == true)
            {
                rigB2D.velocity = movementSpeed * keyboardAndMouseInput;
                aimInput = new Vector3(mouseInput.x, mouseInput.y, 0f);
                

                if(aimInput.magnitude != 0f)
                {
                    gun.transform.up = aimInput.normalized;

                    if (aimInput.x < 0)
                    {
                        spriteRenderer.flipX = true;

                    }
                    else if (aimInput.x > 0)
                    {
                        spriteRenderer.flipX = false;

                    }
                }
            }
            else 
            {
                rigB2D.velocity = movementSpeed * gamepadController1Input;
                aimInput = new Vector3(Input.GetAxis("RStickHorizontalP1"), Input.GetAxis("RStickVerticalP1"), 0f);
                if(aimInput.magnitude != 0f)
                {
                    gun.transform.up = aimInput.normalized;
                    if (aimInput.x < 0)
                    {
                        spriteRenderer.flipX = true;

                    }
                    else if (aimInput.x > 0)
                    {
                        spriteRenderer.flipX = false;

                    }
                }

            }
        }
    }
}
