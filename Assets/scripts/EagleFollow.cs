using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleFollow : MonoBehaviour {
	public GameObject hawk = null;
	public GameObject target=null;
	// Use this for initialization
	void Start () {
		hawk = GameObject.FindGameObjectWithTag ("EagleLead");
		target = GameObject.FindGameObjectWithTag ("cam2");
	}

	// Update is called once per frame
	void Update () {
		if (hawk == null) {
			hawk = GameObject.FindGameObjectWithTag ("EagleLead");
		}
		if(target==null){
			target = GameObject.FindGameObjectWithTag ("cam2");
		}
		transform.position = Vector3.Lerp (transform.position, target.transform.position, Time.deltaTime * 5);
		transform.LookAt (hawk.transform);
	}
}
