

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class LayerSorter : MonoBehaviour {

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
     int offset = 0; // bottom of the object


	// Use this for initialization
	void Awake () {
        
	}
	
	// Update is called once per frame
	void Update () {
        spriteRenderer.sortingOrder = (int)(-transform.position.y) + offset;
		
	}



}
