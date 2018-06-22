using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour {
    //Collapsed (Press + to Expand)
    #region Shield_Stats
    public int shieldCapacity = 500; // This is the health of the shield
    int collisionDamage = 50; // damage applied to enemies
    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player1Bullet" || collider.gameObject.tag == "Player2Bullet")
        {
            shieldCapacity -= 10;
            if (shieldCapacity <= 0)
            {
                DestroyShield();
            }
        }
        if(collider.gameObject.tag == "Player2")
        {
            //TODO: CO-OP Feature
        }
        if (collider.gameObject.tag == "Player1")
        {
            CharacterMovement.playerHealth -= collisionDamage;
            shieldCapacity -= 100;
            if (shieldCapacity <= 0)
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
