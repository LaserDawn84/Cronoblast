/*
 *  Author: Lochlan Kennedy
 *  Date: 11/06/2018
 *  Version Control Repo: https://github.com/Pharah-tato/Cronoblast
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy1Walk : MonoBehaviour
{

    bool isCoOp = false;     // check will be used if I add local multiplayer (Co-Op Single Screen).

    //Collaped (Press the + to Uncollapse)
    #region Position_Vectors
    Vector2 currentPosition; //A vector 2 to store current position
    Vector2 player2Position; //Will Sort this out if time to add multiplayer is sufficient             
    Vector2 player1Position; // Store the player's position. Will be using this with 'currentPosition' to calculate the direction in which the enemy must move.
    #endregion

    //Collaped (Press the + to Uncollapse)
    #region Enemy_Stats
    [SerializeField]
    float movementSpeedEnemy = 3f; //enemy movement speed multiplier

    public int enemyHealth = 1000; //Health of the Enemy

    public int enemyPower = 100; //Power Resource Pool for the Enemy
    #endregion

    //Collaped (Press the + to Uncollapse)
    #region Objects_And_Components
    Rigidbody2D rigB2DEnemy; //stores the rigidbody for the enemy

    SpriteRenderer spriteRenderer; //stores the sprite renderer

    [SerializeField]
    GameObject player; // stores the player game object

    [SerializeField]
    GameObject player2; //stores GameObject for Player 2 (for Later Implementation of Co-Op)

    [SerializeField]
    GameObject gun; // stores the enemy's gun.
    #endregion


    //On Awake used to get and store Components
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
        Movement();
    }

    //Movement For The Enemy
    void Movement()
    {

        currentPosition = new Vector2(transform.position.x,transform.position.y); // used to calculate magnitude
        player1Position = player.transform.position;
        rigB2DEnemy.velocity = movementSpeedEnemy * (currentPosition - player1Position).normalized; 

        if(currentPosition.x < 0)
        {
            spriteRenderer.flipX = true; // if less than zero, then set flipX to true thus showing left walk.
            
        }
        else if (currentPosition.x > 0)
        {
            spriteRenderer.flipX = false; // if zero or greater than zero, then set flipX to false thus showing right walk.
            
        }
        
    }
}
