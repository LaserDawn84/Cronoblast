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

    //bool isCoOp = false;     // check will be used if I add local multiplayer (Co-Op Single Screen).

    //Collaped (Press the + to Expand)
    #region Position_Vectors
    Vector3 currentPosition; //A vector 2 to store current position
    Vector3 player2Position; //Will Sort this out if time to add multiplayer is sufficient             
    Vector3 player1Position; // Store the player's position. Will be using this with 'currentPosition' to calculate the direction in which the enemy must move.
    #endregion

    //Collaped (Press the + to Expand)
    #region Enemy_Stats
    [SerializeField]
    float movementSpeedEnemy = 3f; //enemy movement speed multiplier

    public int enemyHealth = 1000; //Health of the Enemy

    public int enemyPower = 100; //Power Resource Pool for the Enemy

    int bulletDamageReceivedPerShot = 50; // Damage that this enemy Takes

    public static int enemyCount; // counts alive enemies
    #endregion

    //Collaped (Press the + to Expand)
    #region Objects_And_Components
    Rigidbody2D rigB2DEnemy; //stores the rigidbody for the enemy

    SpriteRenderer spriteRenderer; //stores the sprite renderer

    [SerializeField]
    GameObject player1; // stores the player game object

    //[SerializeField]
    //GameObject player2; //stores GameObject for Player 2 (for Later Implementation of Co-Op)

    [SerializeField]
    GameObject gun; // stores the enemy's gun.

    [SerializeField]
    GameObject bullet; // stores the details of the bullet prefab.
    GameObject bulletClone;
    #endregion

    #region Visual_Effects
    [SerializeField]
    GameObject deathExplosionEffect;

    [SerializeField]
    GameObject shield;
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
        enemyCount += 1;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        ShootCheck();
        DeathCheck();
    }

    void LateUpdate()
    {
        GunAim();
    }

    //Movement For The Enemy
    void Movement()
    {

        currentPosition = new Vector3(transform.position.x,transform.position.y,0); // used to calculate magnitude
        player1Position = player1.transform.position;
        rigB2DEnemy.velocity = player1Position.normalized * movementSpeedEnemy;

        if(currentPosition.x < 0)
        {
            spriteRenderer.flipX = true; // if less than zero, then set flipX to true thus showing left walk.
            
        }
        else if (currentPosition.x > 0)
        {
            spriteRenderer.flipX = false; // if zero or greater than zero, then set flipX to false thus showing right walk.
            
        }
        
    }
    void GunAim()
    {
        if (gun != null)
        {
            gun.transform.up = new Vector3(player1.transform.position.x, player1.transform.position.y, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player1Bullet" || collision.gameObject.tag == "Player2Bullet")
        {
            enemyHealth -= bulletDamageReceivedPerShot;
            DeathCheck();
        }
    }
    void DeathCheck()
    {
        if (enemyHealth <= 0)
        {
            player1.GetComponent<CharacterMovement>().points += 10;
            player1.GetComponent<CharacterMovement>().enemiesKilled += 1;
            KillRobot();

        }
    }

    void KillRobot()
    {
        Instantiate(deathExplosionEffect,transform.position,transform.rotation);
        enemyCount -= 1;
        Destroy(gameObject);
    }

   void ShootCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5.0f); // creates an overlap circle which will then grab all colliders within the circle and store them in an array
                                                                                       //for each collider add force.
        foreach (Collider2D hit in colliders)
        {
            if(hit.gameObject.tag == "Player1")
            {
                Shoot();
            }
        }
    }
    void Shoot()
    {
        bulletClone = Instantiate(bullet, gun.transform.position, gun.transform.rotation, gameObject.transform);// spawns a bullet and sets it as a child of the player.
        bulletClone.GetComponent<Rigidbody2D>().AddForce(player1.transform.position.normalized * 20f, ForceMode2D.Impulse); // applies force to the bullet in the direction of the aim input.
    }
}
