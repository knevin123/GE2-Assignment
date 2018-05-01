using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class StartState : State
{
	TakeOff take;

	public override void Enter()
	{
		
		take = owner.GetComponent<TakeOff> ();
		take.enabled = !take.enabled;
		owner.ChangeStateDelayed (new Attack (), 10f);
	}

	public override void Exit()
	{
		//owner.CancelDelayedStateChange ();
	}

	public override void Think()
	{

	}
}

class Attack : State
{
	Boid boid;
	TakeOff take;
	Seek seek;
	Shooting shoot;
	GameObject[] enemies;
	public override void Enter()
	{
		take = owner.GetComponent<TakeOff> ();
		seek = owner.GetComponent<Seek> ();
		shoot = owner.GetComponent<Shooting> ();
		take.enabled =!take.enabled;
		seek.enabled =!seek.enabled;
		shoot.enabled = !shoot.enabled;
		shoot.target = GameObject.FindGameObjectWithTag ("hawk");
	}
	public override void Think()
	{
		enemies = GameObject.FindGameObjectsWithTag ("hawk");
		if (seek.targetGameObject == null) {
			seek.targetGameObject = GameObject.FindGameObjectWithTag ("hawk");
		}
		if (shoot.target == null) {
			shoot.target = GameObject.FindGameObjectWithTag ("hawk");
		}
		if (enemies.Length == 0) {
			owner.ChangeState (new Patrol ());
		}
	}
	public override void Exit()
	{
		
	}
}
class Patrol : State
{
	Boid l;
	Seek seek;
	Shooting shoot;
	Wander wander;
	OffsetPursue offset;
	FollowPath pathFollow;
	GameObject patrolPath=GameObject.FindGameObjectWithTag ("path");
	GameObject leader=GameObject.FindGameObjectWithTag("EagleLead");
	GameObject[] allies;
	public override void Enter()
	{
		seek = owner.GetComponent<Seek> ();
		shoot = owner.GetComponent<Shooting> ();
		offset = owner.GetComponent<OffsetPursue> ();
		//wander = owner.GetComponent<Wander> ();
		if (owner.gameObject.tag == "EagleLead") {
			pathFollow = owner.GetComponent<FollowPath> ();
			pathFollow.enabled = !pathFollow.enabled;
			pathFollow.path = patrolPath.GetComponent<Path> ();
		}
		if (owner.gameObject.tag == "Eagle") {
			l = leader.GetComponent<Boid>();
			offset.enabled = !offset.enabled;
			offset.leader = l;
		}
		seek.enabled =!seek.enabled;
		shoot.enabled = !shoot.enabled;
		//wander.enabled = !wander.enabled;
	}
	public override void Think()
	{
		allies = GameObject.FindGameObjectsWithTag ("Eagle");
		if (allies.Length == 0) {
			owner.ChangeState (new Pause ());
		}
	}
	public override void Exit()
	{

	}
}
class Pause : State
{
	Boid l;
	Seek seek;
	Shooting shoot;
	Wander wander;
	OffsetPursue offset;
	FollowPath pathFollow;
	GameObject patrolPath=GameObject.FindGameObjectWithTag ("path");
	GameObject leader=GameObject.FindGameObjectWithTag("EagleLead");
	GameObject[] allies;
	public override void Enter()
	{
		seek = owner.GetComponent<Seek> ();
		shoot = owner.GetComponent<Shooting> ();
		offset = owner.GetComponent<OffsetPursue> ();
		//wander = owner.GetComponent<Wander> ();
		pathFollow.enabled = !pathFollow.enabled;
		//offset.enabled = !offset.enabled;
		seek.enabled =!seek.enabled;
		shoot.enabled = !shoot.enabled;
		//wander.enabled = !wander.enabled;
	}
	public override void Think()
	{
		allies = GameObject.FindGameObjectsWithTag ("Eagle");
		if (allies.Length == 0) {
			owner.ChangeState (new Pause ());
		}
	}
	public override void Exit()
	{

	}
}

public class EagleController: MonoBehaviour
{
	public bool canIdle = true;
	public void Restart()
	{
		GetComponent<StateMachine> ().ChangeState (new StartState ());
	}

	// Use this for initialization
	void Start () {
		Restart();
	}

	// Update is called once per frame
	void Update () {
	}
}
