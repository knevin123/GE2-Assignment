﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Bullet") {
			Destroy (this.gameObject, 1);
		}
	}
}
