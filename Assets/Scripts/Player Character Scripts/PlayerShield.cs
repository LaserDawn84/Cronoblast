﻿/*
 *  Author: Lochlan Kennedy
 *  Date: 11/06/2018
 *  Version Control Repo: https://github.com/Pharah-tato/Cronoblast
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerShield : MonoBehaviour {


    //Collapsed (Press + to Expand)
    #region Shield_Stats
    public int shieldCapacity = 500; // This is the health of the shield
    int powerCost = 50; // costs half the power resource of The Player if no buffs are applied to the player's Power Resource Pool
    int collisionDamage = 10; // damage applied to enemies
    #endregion

    #region Parent_Scripts
        [SerializeField]
        GameObject playerMovementScript; //Player's MovementScript
    #endregion


    //Awake is used to load and store component references
    void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        if(playerMovementScript != null)
        {
            playerMovementScript.GetComponent<CharacterMovement>().isShieldActive = true; // when this starts the isShieldActive boolean is set to true, stopping duped shields
            playerMovementScript.GetComponent<CharacterMovement>().powerResourceValue = playerMovementScript.GetComponent<CharacterMovement>().powerResourceValue - powerCost; //sets the player's power resource to the new value. (current - cost)

        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}