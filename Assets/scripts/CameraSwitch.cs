using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {
	public Camera hawkCam;
	public Camera eagleCam;
	// Use this for initialization
	void Start () {
		hawkCam.enabled = true;
		eagleCam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.C)) {
			hawkCam.enabled = !hawkCam.enabled;
			eagleCam.enabled = !eagleCam.enabled;
		}
	}
}
