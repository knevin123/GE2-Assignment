using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour {

	public float gap = 20;
	public float followers = 2;
	public GameObject prefab;
	public Vector3 pos1=new Vector3(79,10,125);
	public Vector3 pos2=new Vector3(60,10,-110);
	public Vector3 pos3=new Vector3(160,10,85);
	Seek seek;
	Shooting shoot;
	GameObject[] enemies;
	private void Start()
	{
		GameObject leader = GameObject.Instantiate<GameObject>(prefab);
		enemies = GameObject.FindGameObjectsWithTag ("hawk");
		leader.transform.parent = this.transform;
		leader.transform.position = pos1;
		leader.transform.rotation = this.transform.rotation;
		leader.tag = "EagleLead";
		shoot = leader.GetComponent<Shooting> ();
		seek = leader.GetComponent<Seek> ();
		seek.targetGameObject = enemies[0];
		shoot.target = enemies [0];
		for (int i = 1; i <=followers; i++)
		{
			Vector3 offset = new Vector3(gap * i, 0, - gap * i);
			GameObject follower = CreateFollower(offset, leader.GetComponent<Boid>(),1);
			offset = new Vector3(- gap * i, 0, - gap * i);
			follower = CreateFollower(offset, leader.GetComponent<Boid>(),2);

		}
	}

	GameObject CreateFollower(Vector3 offset, Boid leader,int i)
	{
		GameObject follower = GameObject.Instantiate<GameObject>(prefab);
		follower.tag = "Eagle";
		if (i == 1) {
			follower.transform.position = pos2;	
			seek = follower.GetComponent<Seek> ();
			seek.targetGameObject = enemies[1];
			shoot = follower.GetComponent<Shooting> ();
			shoot.target = enemies[1];
		} else {
			follower.transform.position = pos3;
			seek = follower.GetComponent<Seek> ();
			seek.targetGameObject = enemies[2];
			shoot = follower.GetComponent<Shooting> ();
			shoot.target = enemies[2];
		}
		follower.transform.parent = this.transform;
		follower.transform.rotation = this.transform.rotation;
		//OffsetPursue op = follower.AddComponent<OffsetPursue>();
		//op.leader = leader;
		return follower;
	}


	// Update is called once per frame
	void Update () {

	}
}