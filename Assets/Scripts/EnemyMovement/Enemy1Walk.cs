/*/
 *  Author: Lochlan Kennedy
 *  Date: 11/06/2018
 *  Version Control Repo: https://github.com/Pharah-tato/Cronoblast
/*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(Rigidbody2D))]
public class Enemy1Walk : MonoBehaviour
{
    Animator enemyAnimator1; //Used to store the animator component
    Vector2 currentPosition; //A vector 2 to store current position
                             // Vector2 player2Position; //Will Sort this out if time to add multiplayer is sufficient
                         
    Vector2 playersPosition; // Store the player's position. Will be using this with 'currentPosition' to calculate the direction in which the enemy must move.
                             //bool isCoOp = false; // check will be used if I add local multiplayer (Co-Op Single Screen).

    Vector2 distanceFromPlayerToEnemy; //stores the distance to target.
    Rigidbody2D rigB2DEnemy; //stores the rigidbody for the enemy
    SpriteRenderer spriteRenderer; //stores the sprite renderer

    [SerializeField]
    GameObject player; // stores the player game object

    [SerializeField]
    GameObject player2; //stores GameObject for Player 2 (for Later Implementation of Co-Op)

    float distanceMagnitude;

    // Use this for initialization
    void Start()
    {
        enemyAnimator1.GetComponent<Animator>();
        spriteRenderer.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Movement()
    {

        currentPosition = new Vector2(transform.position.x,transform.position.y);
        playersPosition = player.transform.position;

        distanceFromPlayerToEnemy = playersPosition - currentPosition;
        distanceMagnitude = distanceFromPlayerToEnemy.magnitude;

        if(distanceMagnitude < 0)
        {
            spriteRenderer.flipX = true;
            enemyAnimator1.SetFloat("Speed", distanceMagnitude); // sets the speed parameter for the animator to either set it to idle or walk.
        }
        else
        {
            spriteRenderer.flipX = false; // if
            enemyAnimator1.SetFloat("Speed", distanceMagnitude); // sets the speed parameter for the animator to either set it to idle or walk.
        }
        //playersPosition = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")); //sets the current position to the current player's input
        //player2Position = newVector2(Input.GetAxis("P2Horizontal"),Input.GetAxis("P2Vertical"));
        //These are place holder logics the actual movement will be a shared variable from character movement scripts.
    }
}
