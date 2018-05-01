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
	bool spawn=false;
	bool end=false;
	GameObject[] enemies;
	System.Collections.IEnumerator SpawnHawks(){
		yield return new WaitForSeconds (5);
		while (end==false) {
			yield return new WaitForSeconds (1);
			GameObject[] hawk = GameObject.FindGameObjectsWithTag ("hawk");
			enemies = GameObject.FindGameObjectsWithTag ("Eagle");
			//Debug.Log (hawk.Length);
			if (hawk.Length == 0) {
				spawn = true;
			}
			if (hawk.Length == 2) {
				spawn = false;
			}
			if (spawn) {
				GameObject follower = GameObject.Instantiate<GameObject>(prefab);
				Seek seek2 = follower.AddComponent<Seek>();
				seek2.targetGameObject = enemies[0];
				Shooting shoot2 = follower.GetComponent<Shooting>();
				shoot2.enabled = !shoot2.enabled;
				shoot2.target= enemies[0];
				follower.tag = "hawk";
				follower.transform.position = new Vector3(-150,70,130);
				follower = GameObject.Instantiate<GameObject>(prefab);
				follower.tag = "hawk";
				follower.transform.position = new Vector3(-150,70,100);
				Shooting shoot3 = follower.GetComponent<Shooting>();
				shoot3.enabled = !shoot3.enabled;
				shoot3.target= enemies[1];
				Seek seek3 = follower.AddComponent<Seek>();
				seek3.targetGameObject = enemies[1];

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
			(150
				,Random.Range(50f,100f)
				,-300
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
		StartCoroutine (SpawnHawks());
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
