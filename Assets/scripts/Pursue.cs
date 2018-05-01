using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Pursue : SteeringBehaviour
{
	public GameObject target;
    Vector3 targetPos;
	public Boid tar;
    public void Start()
    {

    }

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, targetPos);
        }

    }

    public override Vector3 Calculate()
    {
		tar=target.GetComponent<Boid> ();
        float dist = Vector3.Distance(target.transform.position, transform.position);
        float time = dist / boid.maxSpeed;

        targetPos = target.transform.position
            + (time * tar.velocity);

        return boid.SeekForce(targetPos);
    }
}
