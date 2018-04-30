using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOff : SteeringBehaviour {

	Rigidbody rb;
	public float power = 10;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * power*Time.deltaTime, Space.World);
	}
	public override Vector3 Calculate()
	{
		return new Vector3(0,0,0);
	}
}
