using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentController : MonoBehaviour {
	Seek seek;
	TakeOff take;
	Arrive arrive;
	OffsetPursue offset;
	Pursue pursue;
	Wander wander;
	// Use this for initialization
	void Start () {
		
	}
	Boid getBoid(){
		return gameObject.GetComponent<Boid> ();	
	}
	// Update is called once per frame
	void Update () {
		
	}
	void EnableComponent(SteeringBehaviour c){
		if(c!=null){
			c.enabled = !c.enabled;
		}
	}
}
