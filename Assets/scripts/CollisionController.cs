using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter(Collider collision){
		if (collision.gameObject.tag == "Bullet") {
			ParticleSystem explosion = GetComponent<ParticleSystem> ();
			explosion.Play ();
			Destroy (this.gameObject,explosion.duration);
		}
	}
}
