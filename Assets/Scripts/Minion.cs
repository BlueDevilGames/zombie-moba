using UnityEngine;
using System.Collections;

public class Minion : Moveable {

	Vector3 destination;

	// Use this for initialization
	public override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () {
		if (target == null) {
			SetDestination(destination);
		}
		else if (Vector3.Distance (target.GetComponentInParent<Transform> ().position, GetComponentInParent<Transform> ().position) < attackRange) {
			target.TakeDamage(curAttackDamage);
		}
		base.Update ();
	}

	public void SetDestination(Vector3 dest) {
		this.destination = dest;
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = destination;
	}
}
