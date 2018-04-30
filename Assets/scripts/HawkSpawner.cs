using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HawkSpawner : MonoBehaviour {

	public float gap = 20;
	public float followers = 2;
	public GameObject prefab;
	Vector3 rand;
	public GameObject target;
	public GameObject enemy;

	private void Start()
	{
		GameObject leader = GameObject.Instantiate<GameObject>(prefab);
		leader.tag = "hawkLeader";
		//rand = Random.insideUnitCircle*300f;
		rand = Random.onUnitSphere * 600;
		leader.transform.parent = this.transform;
		leader.transform.position = new Vector3
			(rand.x
				,Random.Range(30f,100f)
				,rand.z
			);
		leader.transform.rotation = this.transform.rotation;
		target = GameObject.FindGameObjectWithTag ("Base");
		Seek seek = leader.AddComponent<Seek>();
		seek.target = target.transform.position;


		for (int i = 1; i <=followers; i++)
		{
			Vector3 offset = new Vector3(gap * i, 0, - gap * i);
			GameObject follower = CreateFollower(offset, leader.GetComponent<Boid>());
			offset = new Vector3(- gap * i, 0, - gap * i);
			follower = CreateFollower(offset, leader.GetComponent<Boid>());            
		}
	}

	GameObject CreateFollower(Vector3 offset, Boid leader)
	{
		GameObject follower = GameObject.Instantiate<GameObject>(prefab);
		follower.transform.position = leader.transform.TransformPoint(-offset);
		OffsetPursue op = follower.AddComponent<OffsetPursue>();
		op.leader = leader;
		return follower;
	}


	// Update is called once per frame
	void Update () {
		enemy=GameObject.FindGameObjectWithTag ("Hawk");

	}
}
