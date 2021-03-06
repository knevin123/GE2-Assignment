﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject hawk = null;
	public GameObject target=null;
	// Use this for initialization
	void Start () {
		hawk = GameObject.FindGameObjectWithTag ("hawk");
		target = GameObject.FindGameObjectWithTag ("cam1");
	}
	
	// Update is called once per frame
	void Update () {
		if (hawk == null) {
			hawk = GameObject.FindGameObjectWithTag ("hawk");
		}
		if(target==null){
			target = GameObject.FindGameObjectWithTag ("cam1");
		}
		transform.position = Vector3.Lerp (transform.position, target.transform.position, Time.deltaTime * 5);
		transform.LookAt (hawk.transform);
	}
}
