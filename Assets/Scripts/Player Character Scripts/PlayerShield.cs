/*
 *  Author: Lochlan Kennedy
 *  Date: 11/06/2018
 *  Version Control Repo: https://github.com/Pharah-tato/Cronoblast
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShield : MonoBehaviour {


    //Collapsed (Press + to Expand)
    #region Shield_Stats
    public int shieldCapacity = 500; // This is the health of the shield
    int collisionDamage = 1000; // damage applied to enemies
    #endregion

    #region Parent_Scripts
        [SerializeField]
        GameObject playerMovementScript; //stores the game object that has the "Character Movement" script attached.
    #endregion

    bool isActive;

    //Awake is used to load and store component references
    void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //Checks if Enemy or Enemy Bullet is Colliding with the shield.
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "EnemyBullet")
        {
            shieldCapacity -= 10;
            if (shieldCapacity <= 0)
            {
                DestroyShield();
            }
        }

        if(collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<Enemy1Walk>().enemyHealth -= collisionDamage;
            shieldCapacity -= 100;
            if(shieldCapacity <= 0)
            {
                DestroyShield();
            }
        }
    }
    void DestroyShield()
    {
        Destroy(gameObject);
    }
}
