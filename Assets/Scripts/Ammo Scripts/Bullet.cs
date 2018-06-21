using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    GameObject bulletDestructionEffect;
    GameObject bulletDestructionEffectCopy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void BulletDeath()
    {
        bulletDestructionEffectCopy = Instantiate(bulletDestructionEffect, gameObject.transform.position, gameObject.transform.rotation);
        

    }
}
