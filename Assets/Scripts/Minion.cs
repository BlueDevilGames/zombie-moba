using UnityEngine;
using System.Collections;

public class Minion : Moveable {

	Vector3 destination;
	bool attacking;

	// Use this for initialization
	public override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () {
		doTargetActions ();
		base.Update ();
	}

	public void SetFinalDestination(Vector3 dest) {
		this.destination = dest;
		setDestination (dest);
	}

	void setDestination(Vector3 dest) {
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = dest;
	}

	void OnTriggerEnter(Collider other) {
		GameObject obj = other.gameObject;
		Unit unit = obj.GetComponent<Unit> ();
		if (unit!=null && unit.team != team  && unit.team!=0) {
			if(target == null) {
				target = unit;
			}
			unitsInRange.Add(unit);
		}
	}

	void OnTriggerExit(Collider other) {
		Unit unit = other.gameObject.GetComponent<Unit> ();
		if (unit != null) {
			unitsInRange.Remove (other.gameObject.GetComponent<Unit>());
		}
	}

	void takeNewTarget(Unit unit) {
		GetComponentInParent<NavMeshAgent> ().SetDestination (unit.GetComponentInParent<Transform>().position);
	}
	
	void doTargetActions() {
		if (target == null || target.Equals (null)) { //second equals is in case of a destroyed (dead) object
			if (unitsInRange.Count > 0) {
				Unit unit = GetClosestUnit (); //this function could possibly change the size of unitsInRange to 0
				target = unit;
			} 
			else {
				setDestination (destination);
			}
		} 
		else if (Vector3.Distance (target.GetComponentInParent<Transform> ().position, GetComponentInParent<Transform> ().position) < attackRange) {
			setDestination (GetComponentInParent<Transform> ().position);
			target.TakeDamage (curAttackDamage);
		}
		else {
			setDestination (target.GetComponentInParent<Transform> ().position);
		}

	}
}
