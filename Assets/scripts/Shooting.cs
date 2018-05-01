using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	public GameObject bulletSpawnPoint;
	public GameObject bulletPrefab;
	public GameObject target;
	public bool fire = true;
	//co-routine to shoot bullets
	IEnumerator Shoot() {
		GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
		bullet.transform.position = bulletSpawnPoint.transform.position;
		bullet.transform.rotation = transform.rotation;
		fire = false;
		yield return new WaitForSeconds (4);
		fire = true;

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 directionToTarget = target.transform.position -transform.position;
		float angle = Vector3.Angle( directionToTarget,transform.forward);
		//Debug.Log (Mathf.Abs(angle));
		if (Mathf.Abs (angle) < 30) {
			//Debug.Log ("target is in front of me");
			if (fire == true) {
				StartCoroutine ("Shoot");
			}
		}
		
	}
}
