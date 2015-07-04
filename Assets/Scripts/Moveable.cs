using UnityEngine;
using System.Collections;

public class Moveable : Unit {
	
	public int baseSpeed;
	public float attackRange;
	protected Unit target;
	protected int curSpeed;

	protected NavMeshAgent agent;

	// Use this for initialization
	public override void Start () {
		curSpeed = baseSpeed;
		agent = GetComponentInParent<NavMeshAgent> ();
		agent.speed = baseSpeed;
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update ();
	}

	public void updateTarget(Unit unit) {
		target = unit;
	}

}
