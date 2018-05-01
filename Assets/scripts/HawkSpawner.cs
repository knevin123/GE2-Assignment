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
	bool spawn;
	bool end=false;
	System.Collections.IEnumerator SpawnHawks(){
		yield return new WaitForSeconds (5);
		while (end==false) {
			GameObject[] hawk = GameObject.FindGameObjectsWithTag ("hawk");
			Debug.Log (hawk.Length);
			if (hawk.Length == 0) {
				spawn = true;
			}
			if (hawk.Length == 3) {
				spawn = false;
			}
			if (spawn) {
				GameObject leader = GameObject.Instantiate<GameObject>(prefab);
				leader.transform.parent = this.transform;
				leader.transform.position = new Vector3(100,40,100);
				leader.transform.rotation = this.transform.rotation;
				leader.tag = "hawk";
				for (int i = 1; i <=followers; i++)
				{
					Vector3 offset = new Vector3(gap * i, 0, - gap * i);
					GameObject follower = GameObject.Instantiate<GameObject>(prefab);
					follower.tag = "hawk";
					follower.transform.position = leader.transform.TransformPoint(offset);
					offset = new Vector3(- gap * i, 0, - gap * i);
					follower = GameObject.Instantiate<GameObject>(prefab);
					follower.transform.position = leader.transform.TransformPoint(offset);
				}
				end = true;
			}
		}
	}
	private void Start()
	{
		GameObject leader = GameObject.Instantiate<GameObject>(prefab);
		leader.tag = "hawk";
		//rand = Random.insideUnitCircle*300f;
		//rand = Random.onUnitSphere * 1000;
		leader.transform.parent = this.transform;
		leader.transform.position = new Vector3
			(300
				,Random.Range(50f,100f)
				,-500
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
		//StartCoroutine (SpawnHawks());
	}

	GameObject CreateFollower(Vector3 offset, Boid leader)
	{
		GameObject follower = GameObject.Instantiate<GameObject>(prefab);
		follower.tag = "hawk";
		follower.transform.position = leader.transform.TransformPoint(offset);
		//OffsetPursue op = follower.AddComponent<OffsetPursue>();
		//op.leader = leader;
		Seek seek = follower.AddComponent<Seek>();
		seek.target = (target.transform.TransformPoint(offset));
		return follower;
	}


	// Update is called once per frame
	void Update () {

	}
}
