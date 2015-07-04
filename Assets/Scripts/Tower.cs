using UnityEngine;
using System.Collections;

public class Tower : Static {

	Unit target;
	
	// Use this for initialization
	public override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () {
		if (target != null) {
			//ONLY DO THIS AT A CERTAIN RATE, needs a fix
			target.TakeDamage(curAttackDamage);
		}
		base.Update ();
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
}
