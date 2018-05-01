using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Flee : SteeringBehaviour {
	public float fleeDistance = 20;
	public float slowingDistance = 10;
	public GameObject target;
	// Use this for initialization
	void Start () {
		target=GameObject.FindGameObjectWithTag ("Eagle");
	}
	
	// Update is called once per frame
	void Update () {
		if(target==null){
			target=GameObject.FindGameObjectWithTag ("Eagle");
		}	
	}
	public override Vector3 Calculate()
	{
		Vector3 toTarget = target.transform.position - transform.position;
		if (toTarget.magnitude > fleeDistance) {
			return Vector3.zero;
		} else {
			toTarget.Normalize ();
			Vector3 desired = toTarget * boid.maxSpeed;
			return boid.velocity - desired;
		}
	}
}
