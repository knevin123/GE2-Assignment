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
		yield return new WaitForSeconds (2);
		fire = true;

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 directionToTarget = transform.position - target.transform.position;
		float angle = Vector3.Angle (directionToTarget,transform.forward);
		if (Mathf.Abs (angle) < 90) {
			Debug.Log ("target infront");
			if (fire == true) {
				StartCoroutine ("Shoot");
			}
		}
	}
}
