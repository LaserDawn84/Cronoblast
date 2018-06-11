/*/
 *  Author: Lochlan Kennedy
 *  Date: 11/06/2018
 *  Version Control Repo: https://github.com/Pharah-tato/Cronoblast
/*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT IS FOR PLAYER 1 WHEN IN Co-Op MODE (Didn't refractor script/class name due to potential screw ups with unity saving me from having to restart the project)

[RequireComponent(typeof(Rigidbody2D),typeof(SpriteRenderer))]// requires the parent object to have components of SpriteRenderer and Rigidbody2D
public class CharacterMovement : MonoBehaviour {

    [SerializeField]
    bool isUsingMouse = false;

    Vector3 keyboardAndMouseInput = Vector3.zero; // for keyboard and mouse
    Vector3 previousKeyboardAndMouseInput = Vector3.zero; //
    Vector3 gamepadController1Input = Vector3.zero; // gamepad for player 1
    //Vector3 gamepadController2Input = Vector3.zero; // gamepad for player 2
    Vector3 mouseAim = Vector3.zero;

    

    [SerializeField]
    float movementSpeed = 4f;

    Rigidbody2D rigB2D;

    [SerializeField]
    GameObject gun;

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

        if(keyboardAndMouseInput != previousKeyboardAndMouseInput)
        {
            isUsingMouse = true;
            previousKeyboardAndMouseInput = keyboardAndMouseInput;
            
        }

        if(keyboardAndMouseInput == previousKeyboardAndMouseInput)
        {
            isUsingMouse = false;
            previousKeyboardAndMouseInput = keyboardAndMouseInput;
        }

        if(gun != null)
        {
            if (isUsingMouse == true)
            {
                rigB2D.velocity = movementSpeed * keyboardAndMouseInput * Time.deltaTime;
            }
            else
            {
                rigB2D.velocity = movementSpeed * gamepadController1Input * Time.deltaTime;
            }
        }
    }
}
