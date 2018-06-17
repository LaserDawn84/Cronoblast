/*/
 *  Author: Lochlan Kennedy
 *  Date: 11/06/2018
 *  Version Control Repo: https://github.com/Pharah-tato/Cronoblast
/*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy1Walk : MonoBehaviour
{
    Vector2 currentPosition; //A vector 2 to store current position
                             // Vector2 player2Position; //Will Sort this out if time to add multiplayer is sufficient
                         
    Vector2 playersPosition; // Store the player's position. Will be using this with 'currentPosition' to calculate the direction in which the enemy must move.
                             //bool isCoOp = false; // check will be used if I add local multiplayer (Co-Op Single Screen).

    Vector2 distanceFromPlayerToEnemy; //stores the distance to target.
    Rigidbody2D rigB2DEnemy; //stores the rigidbody for the enemy
    SpriteRenderer spriteRenderer; //stores the sprite renderer

    [SerializeField]
    float movementSpeedEnemy = 3f; //enemy movement speed multiplier

    [SerializeField]
    GameObject player; // stores the player game object

    [SerializeField]
    GameObject player2; //stores GameObject for Player 2 (for Later Implementation of Co-Op)

    float distanceMagnitude;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigB2DEnemy = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Movement()
    {

        currentPosition = new Vector2(transform.position.x,transform.position.y); // used to calculate magnitude
        playersPosition = player.transform.position;
        rigB2DEnemy.velocity = movementSpeedEnemy * playersPosition; 

        if(currentPosition.x < 0)
        {
            spriteRenderer.flipX = true; // if less than zero, then set flipX to true thus showing left walk.
            
        }
        else if (currentPosition.x > 0)
        {
            spriteRenderer.flipX = false; // if zero or greater than zero, then set flipX to false thus showing right walk.
            
        }
        //playersPosition = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")); //sets the current position to the current player's input
        //player2Position = newVector2(Input.GetAxis("P2Horizontal"),Input.GetAxis("P2Vertical"));
        //These are place holder logics the actual movement will be a shared variable from character movement scripts.
    }
}
