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
	//owner.gameObject.tag = "leader";
	public override void Enter()
	{
		take = owner.GetComponent<TakeOff> ();
		seek = owner.GetComponent<Seek> ();
		shoot = owner.GetComponent<Shooting> ();
		seek.targetGameObject = GameObject.FindGameObjectWithTag ("hawkLeader");
		take.enabled =!take.enabled;
		seek.enabled =!take.enabled;
		shoot.enabled = !shoot.enabled;
		shoot.target = GameObject.FindGameObjectWithTag ("hawkLeader");
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
