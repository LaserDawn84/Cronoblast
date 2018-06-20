/*
 *  Author: Lochlan Kennedy
 *  Date: 11/06/2018
 *  Version Control Repo: https://github.com/Pharah-tato/Cronoblast
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerShield : MonoBehaviour {


    //Collapsed (Press + to Uncollapse)
    #region Shield_Stats
    public int shieldCapacity = 500; // This is the health of the shield
    int powerCost = 50; // costs half the power resource of The Player if no buffs are applied to the player's Power Resource Pool
    int collisionDamage = 10; // damage applied to enemies
    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
