/*
 * Author:
 * Lochlan Kennedy 22/06/2018
 * Referenced https://unity3d.com/learn/tutorials/projects/2d-ufo-tutorial/following-player-camera
 * Version Control Repo: https://github.com/pharahtato/cronoblast
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour {

    [SerializeField]
    GameObject player;

    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
