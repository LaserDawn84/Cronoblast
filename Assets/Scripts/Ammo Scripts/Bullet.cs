/*
 *  Author: Lochlan Kennedy
 *  Date: 11/06/2018
 *  Version Control Repo: https://github.com/Pharah-tato/Cronoblast
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    GameObject bulletDestructionEffect;
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BulletDeath();
    }

    void BulletDeath()
    {
        Instantiate(bulletDestructionEffect, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
