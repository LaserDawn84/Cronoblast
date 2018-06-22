using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    GameObject[] spawnPoints;  // first enemy spawnpoint

    [SerializeField]
    GameObject[] enemyArray; // stores enemy types

    void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Enemy1Walk.enemyCount <= 0)
        {
            int i = 0;
            foreach (GameObject spawnPoint in spawnPoints)
            {
                if(i <= enemyArray.Length)
                {
                    Instantiate(enemyArray[i], spawnPoint.transform.position,spawnPoint.transform.rotation);
                    i++;
                }
                
            }
        }
	}
}
